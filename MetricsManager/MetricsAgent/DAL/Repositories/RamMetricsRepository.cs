using Core;
using Dapper;
using MetricsAgent.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DAL.Repositories
{
    public class RamMetricsRepository : IRamMetricsRepository
    {
        private string _tablename;

        public RamMetricsRepository()
        {
            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
            _tablename = Strings.TableNames[(int)Enums.MetricsNames.Ram];
        }

        public void Create(RamMetric item)
        {
            using (var connection = new SQLiteConnection(Strings.ConnectionString))
            {
                connection.Execute("INSERT INTO " + _tablename + "(value, time) VALUES(@value, @time)",
                new
                {
                    value = item.Value,
                    time = item.Time
                });
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SQLiteConnection(Strings.ConnectionString))
            {
                connection.Execute("DELETE FROM " + _tablename + " WHERE id=@id",
                new
                {
                    id = id
                });
            }
        }

        public void Update(RamMetric item)
        {
            using (var connection = new SQLiteConnection(Strings.ConnectionString))
            {
                connection.Execute("UPDATE " + _tablename + " SET value = @value, time = @time WHERE id = @id",
                new
                {
                    value = item.Value,
                    time = item.Time,
                    id = item.Id
                });
            }
        }

        public IList<RamMetric> GetAll()
        {
            using (var connection = new SQLiteConnection(Strings.ConnectionString))
            {
                return connection.Query<RamMetric>("SELECT Id, Time, Value FROM " + _tablename).ToList();
            }
        }

        public RamMetric GetById(int id)
        {
            using (var connection = new SQLiteConnection(Strings.ConnectionString))
            {
                return connection.QuerySingle<RamMetric>("SELECT Id, Time, Value FROM " + _tablename + " WHERE id = @id",
                new { id = id });
            }
        }

        public IList<RamMetric> GetByTimePeriod(DateTimeOffset timeFrom, DateTimeOffset timeTo)
        {
            long timefrom = timeFrom.ToUnixTimeSeconds();
            long timeto = timeTo.ToUnixTimeSeconds();
            using (var connection = new SQLiteConnection(Strings.ConnectionString))
            {
                return (IList<RamMetric>)connection.Query<RamMetric>(
                    "SELECT Id, Time, Value FROM " + _tablename + " WHERE Time > @timefrom AND Time < @timeto",
                new { timefrom = timefrom, timeto = timeto });
            }
        }

    }
}

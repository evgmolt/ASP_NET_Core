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
    public class CpuMetricsRepository : ICpuMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=True;Max Pool Size=100;";
        private SQLiteConnection _connection;
        private string _tablename;

//        public CpuMetricsRepository(SQLiteConnection connection)
        public CpuMetricsRepository()
        {
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
            _tablename = Strings.TableNames[(int)Enums.MetricsNames.Cpu];
//            this._connection = connection;
        }

        public void Create(CpuMetric item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
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
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("DELETE FROM " + _tablename + " WHERE id=@id",
                new
                {
                    id = id
                });
            }
        }

        public void Update(CpuMetric item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
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

        public IList<CpuMetric> GetAll()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Query<CpuMetric>("SELECT Id, Time, Value FROM " + _tablename).ToList();
            }
        }

        public CpuMetric GetById(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.QuerySingle<CpuMetric>("SELECT Id, Time, Value FROM " + _tablename + " WHERE id = @id",
                new { id = id });
            }
        }

        public IList<CpuMetric> GetByTimePeriod(DateTimeOffset timeFrom, DateTimeOffset timeTo)
        {
            using var cmd = new SQLiteCommand(_connection);
            string stimeFrom = timeFrom.ToUnixTimeSeconds().ToString();
            string stimeTo = timeTo.ToUnixTimeSeconds().ToString();
            cmd.CommandText = "SELECT * FROM " + _tablename + " WHERE (time > " + stimeFrom + ") AND (time < " + stimeTo + ")";
            var returnList = new List<CpuMetric>();
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    returnList.Add(new CpuMetric
                    {
                        Id = reader.GetInt32(0),
                        Value = reader.GetInt32(1),
                        Time = reader.GetInt32(2)
                    });
                }
            }
            return returnList;
        }
    }
}

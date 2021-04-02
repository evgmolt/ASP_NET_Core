﻿using Core;
using Dapper;
using MetricsAgent.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DAL.Repositories
{
    public class NetworkMetricsRepository : INetworkMetricsRepository
    {
        private string _tablename;

        public NetworkMetricsRepository()
        {
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
            _tablename = Strings.TableNames[(int)Enums.MetricsNames.Network];
        }

        public void Create(NetworkMetric item)
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

        public void Update(NetworkMetric item)
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

        public IList<NetworkMetric> GetAll()
        {
            using (var connection = new SQLiteConnection(Strings.ConnectionString))
            {
                return connection.Query<NetworkMetric>("SELECT Id, Time, Value FROM " + _tablename).ToList();
            }
        }

        public NetworkMetric GetById(int id)
        {
            using (var connection = new SQLiteConnection(Strings.ConnectionString))
            {
                return connection.QuerySingle<NetworkMetric>("SELECT Id, Time, Value FROM " + _tablename + " WHERE id = @id",
                new { id = id });
            }
        }

        public IList<NetworkMetric> GetByTimePeriod(DateTimeOffset timeFrom, DateTimeOffset timeTo)
        {
            long timefrom = timeFrom.ToUnixTimeSeconds();
            long timeto = timeTo.ToUnixTimeSeconds();
            using (var connection = new SQLiteConnection(Strings.ConnectionString))
            {
                return (IList<NetworkMetric>)connection.Query<NetworkMetric>(
                    "SELECT Id, Time, Value FROM " + _tablename + " WHERE Time > @timefrom AND Time < @timeto",
                new { timefrom = timefrom, timeto = timeto });
            }
        }
    }
}

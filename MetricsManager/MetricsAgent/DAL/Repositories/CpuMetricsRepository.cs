﻿using Core;
using Dapper;
using MetricsAgent.DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DAL.Repositories
{
    public class CpuMetricsRepository : ICpuMetricsRepository
    {
        private string _tablename;
        private IConfiguration _configuration;
        private string _connectionString;

        public CpuMetricsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetValue<string>("ConnectionString");
            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
            _tablename = Strings.TableNames[(int)Enums.MetricsNames.Cpu];
        }

        public void Create(CpuMetric item)
        {
            using (var connection = new SQLiteConnection(_connectionString))
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
            using (var connection = new SQLiteConnection(_connectionString))
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
            using (var connection = new SQLiteConnection(_connectionString))
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
            using (var connection = new SQLiteConnection(_connectionString))
            {
                return connection.Query<CpuMetric>("SELECT Id, Time, Value FROM " + _tablename).ToList();
            }
        }

        public CpuMetric GetById(int id)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                return connection.QuerySingle<CpuMetric>("SELECT Id, Time, Value FROM " + _tablename + " WHERE id = @id",
                new { id = id });
            }
        }

        public IList<CpuMetric> GetByTimePeriod(DateTimeOffset timeFrom, DateTimeOffset timeTo)
        {
            long timefrom = timeFrom.ToUnixTimeSeconds();
            long timeto = timeTo.ToUnixTimeSeconds();
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    return (IList<CpuMetric>)connection.Query<CpuMetric>(
                    "SELECT Id, Time, Value FROM " + _tablename + " WHERE Time >= @timefrom AND Time <= @timeto",
                    new { timefrom = timefrom, timeto = timeto });
                }
            }
        }
    }
}

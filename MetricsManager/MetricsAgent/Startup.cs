using Core;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            ConfigureSqlLiteConnection(services);
            services.AddScoped<ICpuMetricsRepository, CpuMetricsRepository>();
            services.AddScoped<IDotNetMetricsRepository, DotNetMetricsRepository>();
            services.AddScoped<IHddMetricsRepository, HddMetricsRepository>();
            services.AddScoped<INetworkMetricsRepository, NetworkMetricsRepository>();
            services.AddScoped<IRamMetricsRepository, RamMetricsRepository>();
        }

        private void ConfigureSqlLiteConnection(IServiceCollection services)
        {
            string connectionString = "Data Source=:memory:";
            var connection = new SQLiteConnection(connectionString);
            connection.Open();
            PrepareSchema(connection);
            services.AddSingleton(connection);
        }
        private void PrepareSchema(SQLiteConnection connection)
        {
            for (int i = 0; i < Strings.TableNames.Count(); i++)
            {
                CreateTable(connection, Strings.TableNames[i]);
                FillTable(connection, Strings.TableNames[i]);
            }
        }

        private void CreateTable(SQLiteConnection connection, string tablename)
        {
            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = "DROP TABLE IF EXISTS " + tablename;
                command.ExecuteNonQuery();
                command.CommandText = @"CREATE TABLE " + tablename + "(id INTEGER PRIMARY KEY, value INT, time INT)";
                command.ExecuteNonQuery();
            }
        }

        private string GetDateString(int n)
        {
            DateTimeOffset datetime = DateTimeOffset.Parse(n.ToString().PadLeft(2, '0') + "-01-2020");
            long unixtime = datetime.ToUnixTimeSeconds();
            return unixtime.ToString();
        }

        private void FillTable(SQLiteConnection connection, string tablename)
        {
            int _numOfRecords = 5;
            using (var command = new SQLiteCommand(connection))
            {
                Random rand = new Random();
                for (int i = 0; i < _numOfRecords; i++)
                {
                    command.CommandText = "INSERT INTO " + tablename + "(value, time) VALUES(" + rand.Next(0,100).ToString() +", " + GetDateString(i + 1) + ")";
                    command.ExecuteNonQuery();
                }
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

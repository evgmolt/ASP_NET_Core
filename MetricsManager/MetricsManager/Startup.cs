using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using DAL;
using MetricsManager.DAL.Interfaces;
using AutoMapper;
using MetricsManager.DAL.Repositories;
using FluentMigrator.Runner;
using MetricsManager.Jobs.MetricJobs;
using MetricsManager.Jobs;
using Quartz.Spi;
using Quartz;
using Core;
using Quartz.Impl;
using MetricsManager.Client;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;

namespace MetricsManager
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API сервиса агента сбора метрик",
                    Description = "Описание сервиса",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Студент Евгений Молчков, преподаватель Игорь Владимиров",
                        Email = string.Empty,
                        Url = new Uri("https://geekbrains.ru"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "можно указать под какой лицензией все опубликовано",
                        Url = new Uri("https://example.com/license"),
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddControllers();

            services.AddSingleton<IAgentsRepository, IAgentsRepository>();
            services.AddSingleton<ICpuMetricsRepository, CpuMetricsRepository>();
            services.AddSingleton<IDotNetMetricsRepository, DotNetMetricsRepository>();
            services.AddSingleton<IHddMetricsRepository, HddMetricsRepository>();
            services.AddSingleton<INetworkMetricsRepository, NetworkMetricsRepository>();
            services.AddSingleton<IRamMetricsRepository, RamMetricsRepository>();

            var mapperConfiguration = new MapperConfiguration(mp => mp.AddProfile(new MapperProfile()));
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);

            string _connectionString = Configuration.GetValue<string>("ConnectionString");

            services.AddFluentMigratorCore()
            .ConfigureRunner(rb => rb.AddSQLite()
            .WithGlobalConnectionString(_connectionString)
            .ScanIn(typeof(Startup).Assembly).For.Migrations()
            ).AddLogging(lb => lb
            .AddFluentMigratorConsole());

            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

            int getMetricsInterval = Configuration.GetValue<int>("GetMetricsInterval");
            string cronString = String.Format(Strings.CronString, getMetricsInterval);

            services.AddSingleton<CpuMetricJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(CpuMetricJob),
                cronExpression: cronString));

            services.AddSingleton<DotNetMetricJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(DotNetMetricJob),
                cronExpression: cronString));

            services.AddSingleton<HddMetricJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(HddMetricJob),
                cronExpression: cronString));

            services.AddSingleton<NetworkMetricJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(NetworkMetricJob),
                cronExpression: cronString));

            services.AddSingleton<RamMetricJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(RamMetricJob),
                cronExpression: cronString));

            services.AddHostedService<QuartzHostedService>();

//            services.AddHttpClient();
            services.AddHttpClient<IMetricsAgentClient, MetricsAgentClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMigrationRunner migrationRunner)
        {
            // Включение middleware в пайплайн для обработки Swagger запросов.
            app.UseSwagger();
            // включение middleware для генерации swagger-ui
            // указываем Swagger JSON эндпоинт (куда обращаться за сгенерированной спецификацией
            // по которой будет построен UI).
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API сервиса агента сбора метрик");
//                c.RoutePrefix = string.Empty;
            });

            migrationRunner.MigrateUp();

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

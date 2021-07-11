using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MetricsAgent.DAL;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Repositories;
using System.Data.SQLite;
using Dapper;
using AutoMapper;

namespace MetricsAgent.Core
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MetricsAgent", Version = "v1" });
            });
            var mapperConfiguration = new MapperConfiguration(mapper => mapper.AddProfile(new MapperProfile()));
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
            
            services.AddSingleton<ICpuMetricsRepository, CpuMetricsRepository>();
            services.AddSingleton<IDotNetMetricsRepository, DotNetMetricsRepository>();
            services.AddSingleton<IHddMetricsRepository, HddMetricsRepository>();
            services.AddSingleton<INetworkMetricsRepository, NetworkMetricsRepository>();
            services.AddSingleton<IRamMetricsRepository, RamMetricsRepository>();
            services.AddSingleton<IConnectionManager, ConnectionManager>();

            ConfigureSqlLiteConnection();
        }

        private void ConfigureSqlLiteConnection()
        {
            using (var connection = new SQLiteConnection(ConnectionManager.ConnectionString))
            {
                PrepareSchema(connection);
            }            
        }

        private void PrepareSchema(SQLiteConnection connection)
        {
            // удал€ем таблицу с метриками если она существует в базе данных
            connection.Execute("DROP TABLE IF EXISTS cpumetrics");
            connection.Execute("DROP TABLE IF EXISTS dotnetmetrics");
            connection.Execute("DROP TABLE IF EXISTS hddmetrics");
            connection.Execute("DROP TABLE IF EXISTS networkmetrics");
            connection.Execute("DROP TABLE IF EXISTS rammetrics");

            // заполн€ем Ѕƒ первичными данными
            connection.Execute("CREATE TABLE cpumetrics (id INTEGER PRIMARY KEY, value INT, time INT)");
            connection.Execute("insert into cpumetrics (value, time) values (80, 1623672000), (90, 1623672060), (95, 1623672120), (85, 1623672180), (50, 1623672240)");
            connection.Execute("CREATE TABLE dotnetmetrics (id INTEGER PRIMARY KEY, value INT, time INT)");
            connection.Execute("insert into dotnetmetrics (value, time) values (1, 1623672000), (2, 1623672060), (3, 1623672120), (4, 1623672180), (5, 1623672240)");
            connection.Execute("CREATE TABLE hddmetrics (id INTEGER PRIMARY KEY, value INT, time INT)");
            connection.Execute("insert into hddmetrics (value, time) values (51, 1623672000), (50, 1623672060), (49, 1623672120), (48, 1623672180), (47, 1623672240)");
            connection.Execute("CREATE TABLE networkmetrics (id INTEGER PRIMARY KEY, value INT, time INT)");
            connection.Execute("insert into networkmetrics (value, time) values (80, 1623672000), (10, 1623672060), (5, 1623672120), (15, 1623672180), (30, 1623672240)");
            connection.Execute("CREATE TABLE rammetrics (id INTEGER PRIMARY KEY, value INT, time INT)");
            connection.Execute("insert into rammetrics (value, time) values (80, 1623672000), (85, 1623672060), (85, 1623672120), (85, 1623672180), (80, 1623672240)");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MetricsAgent v1"));
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

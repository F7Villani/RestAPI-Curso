using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestAPI.Models.Context;
using RestAPI.Business;
using RestAPI.Business.Implementations;
using RestAPI.Repository;
using RestAPI.Repository.Implementations;
using Serilog;
using System;
using System.Collections.Generic;

namespace RestAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;

            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            // Conex�o banco de dados
            string connection = Configuration["MySQLConnection:MySQLConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connection));

            // Versionamento de endpoints
            services.AddApiVersioning();

            // Inje��o de depend�ncia
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonBusiness, PersonBusiness>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookBusiness, BookBusiness>();

            if (Environment.IsDevelopment())
            {
                MigrateDatabase(connection);
            }
        }

        private void MigrateDatabase(string connection)
        {
            try
            {
                var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connection);
                var evolve = new Evolve.Evolve(evolveConnection, msg => Log.Information(msg))
                {
                    Locations = new List<string> { "db/Migrations", "db/Dataset" },
                    IsEraseDisabled = true,
                };
                evolve.Migrate();
            }
            catch(Exception ex)
            {
                Log.Error("Migration banco de dados falhou.", ex);
                throw;
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

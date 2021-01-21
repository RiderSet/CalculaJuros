using Calcula.Interfaces;
using Calcula.Services;
using CalculaJuros.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace CalculaJuros
{
    /// <summary>
    /// Classe startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Método ConfigureServices
        /// </summary>
        /// <returns>
        /// Retorna vazio.
        /// </returns>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Contexto>(opt =>
                opt.UseInMemoryDatabase("Calculos"));

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new Info { Title = "CalculaJuros", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                opt.IncludeXmlComments(xmlPath);
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<ICalculo, CalculoService>();
        }

        /// <summary>
        /// Método Configure
        /// </summary>
        /// <returns>
        /// Retorna vazio.
        /// </returns>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CalculaJuros V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

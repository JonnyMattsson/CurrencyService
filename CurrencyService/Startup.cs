using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CurrencyService.Mapping;
using CurrencyService.Middlewares;
using CurrencyService.ServiceCollections;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CurrencyService
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
            services.AddControllers().AddFluentValidation();
            services.AddCurrencyServices();
            services.AddModelValidators();
            services.AddHttpClient();
            services.AddApiVersioning(p =>
            {
                p.DefaultApiVersion = new ApiVersion(1, 0);
                p.AssumeDefaultVersionWhenUnspecified = true;
                p.ReportApiVersions = true;
                p.ApiVersionReader = new HeaderApiVersionReader("api-version");
            });

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var logger = loggerFactory.CreateLogger<Startup>();
            app.ConfigureExceptionHandler(logger);

            app.UseSwagger();
            app.UseSwaggerUI(p =>
            {
                p.SwaggerEndpoint("/swagger/v1/swagger.json", "CurrencyConversion API V1");
            });

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

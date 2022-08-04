using Core.Repositories;
using Core.Services;
using Data;
using Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Web_API
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
           
            //OVO JE NACIN ZA IGNORISANJE CYCLINGA

          // services.AddControllersWithViews()
   //.AddJsonOptions(options =>
      //options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            services.AddControllers();
            services.AddControllers().AddXmlSerializerFormatters();
            services.AddControllers().AddXmlDataContractSerializerFormatters();


            services.AddDbContext<MyDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default"),
               x => x.MigrationsAssembly("Data")));

            //dodavenje DI
            services.AddTransient<ICountryService, CountryService>();
            services.AddScoped<ICountryRepository, CountryRepository>();

            services.AddTransient<ISmsService, SmsService>();
            services.AddScoped<ISmsRepository, SmsRepository>();



            //Dodavanje automappera
            //moramo da kreiramo profiles tako da sam dodao folder profiles
            services.AddAutoMapper(typeof(Startup));  
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

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleGen.Dal;
using Microsoft.EntityFrameworkCore;
using PeopleGen.Dal.Interfaces;

namespace PeopleGen.Web
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
            services.AddRazorPages();
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddControllersWithViews();
            services.AddScoped<PeopleService>();
            services.AddScoped<CityServices>();
            services.AddScoped<BusinessService>();
            services.AddScoped<InventoryService>();
            services.AddDbContext<PeopleDbContext>(options =>
                     options.UseNpgsql(Configuration.GetConnectionString("connection")),ServiceLifetime.Scoped);
            //services.AddHttpClient<SpeciesAPIService, SpeciesAPIService>(c =>
            //{
            //    c.BaseAddress = new Uri("https://www.dnd5eapi.co/api/");
            //});
            //services.AddScoped<SpeciesAPIService>();
            services.AddSingleton<ISpeciesAPI, SpeciesAPIService>();
            services.AddHttpClient("SpeciesAPICall", c => c.BaseAddress = new Uri("https://www.dnd5eapi.co/api/"));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}

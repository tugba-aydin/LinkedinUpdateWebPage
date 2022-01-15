using BLL.Interfaces;
using BLL.Services;
using DAL.Contexts;
using DAL.Repository;
using DAL.UoW;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PresentationLayer", Version = "v1" });
            });
            services.AddDbContext<LinkedinWebPageContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddCors(option => option.AddPolicy
            ("Cors", builder => {
                builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
            }));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitofWork, UnitofWork>();
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IExperienceService, ExperienceService>();
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<ISkillService, SkillService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PresentationLayer v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseCors("Cors");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources")
            });
        }
    }
}

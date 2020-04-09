using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ManutationItemsApp.DAL;
using ManutationItemsApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors;
using AutoMapper;
using ManutationItemsApp.Configuration;
using ManutationItemsApp.Service.Contracts;
using ManutationItemsApp.Service.Implementations;
using ManutationItemsApp.DAL.Contracts;
using ManutationItemsApp.DAL.Implementations;
using ManutationItemsApp.DAL.Contracts.Repositories;
using ManutationItemsApp.DAL.Repositories;
using ManutationItemsApp.DAL.Implementations.Repositories;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.Net.Http.Headers;
using System.Buffers;

namespace ManutationItemsApp
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutomapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
            options.UseMemberCasing())
            .AddNewtonsoftJson(options=>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddKendo();

            //services.AddScoped<IManutationService, ManutationService>();
            services.AddScoped<IAssetService, AssetService>();
            services.AddScoped<IManutationRepository, ManutationRepository>();
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<IAssetRepository, AssetRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IManutationTypeRepository, ManutationTypeRepository>();
            services.AddScoped<IUserManutationsStagesRepository, UserManutationStagesRepository>();
            services.AddScoped<IManutationStageRepository, ManutationStageRepository>();
            services.AddScoped<IErrorCodeRepository, ErrorCodeRepository>();
            services.AddScoped<IToolRepository, ToolRepository>();
            services.AddScoped<IConsumableRepository, ConsumableRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IAssetFileRepository, AssetFileRepository>();
            services.AddScoped<IItemFileRepository, ItemFileRepository>();
            services.AddScoped<IAssetItemRepository, AssetItemRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Servicios.BusinessLogic.Implementations;
using Servicios.BusinessLogic.Intefaces;
using Servicios.DataAccess;
using Servicios.UnitOfWork;
using Servicios.WebApi.Authentication;
using Servicios.WebApi.Controllers.GlobalErrorHandling;
using System.IO;

namespace Servicios.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Enable CORS

            /*inicio pruebas*/

            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().Build();
                });
            });

           

            //services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            //{
            //    builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
            //}));

            //services.AddCors(options =>
            //{
            //    options.AddPolicy(MyAllowSpecificOrigins,
            //    builder =>
            //    {
            //        builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
            //    });
            //});
            /*fin pruebas*/

            //Inyección de dependencias de capa de lógica.
            services.AddTransient<ISupplierLogic, SupplierLogic>();
            services.AddTransient<IOrderLogic, OrderLogic>();
            services.AddTransient<ICustomerLogic, CustomerLogic>();
            services.AddTransient<ITokenLogic, TokenLogic>();
            services.AddTransient<IUsuariosLogic, UsuariosLogic>();
            services.AddTransient<IMotocicletaLogic, MotocicletaLogic>();
            services.AddTransient<IHojaRecibimientoLogic, HojaRecibimientoLogic>();
            services.AddTransient<IMantenimientoLogic, MantenimientoLogic>();

            services.AddSingleton<IUnitOfWork>(option => new ServiciosUnitOfWork(
                Configuration.GetConnectionString("Northwind")
                ));

            var tokenProvider = new JwtProvider("issuer", "audience", "northwind_2000");
            services.AddSingleton<ITokenProvider>(tokenProvider);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options=> 
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = tokenProvider.GetValidationParameters();
                });
            services.AddAuthorization(auth => {
                auth.DefaultPolicy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            //Enable CORS
            app.UseCors("EnableCORS");
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources")
            });

            //Pruebas Inicio

            //app.UseCors(MyAllowSpecificOrigins);

            //app.UseCors(builder => builder
            //    .AllowAnyOrigin()
            //    .AllowAnyMethod()
            //    .AllowAnyHeader()
            //    .AllowCredentials());

            //app.UseCors("ApiCorsPolicy");
            //Pruebas Fin

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.ConfigureExceptionHandler();
            app.UseMvc();
        }
    }
}

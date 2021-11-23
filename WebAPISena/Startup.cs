using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Sena.core.Interfaces;
using Sena.core.Interfaces.Repository;
using Sena.core.Services;
using Sena.infraestructure.Data;
using Sena.infraestructure.Repositorio;
using System;
using AutoMapper;
using Sena.core.Models;
using Sena.core.Interfaces.IServices;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebAPISena.JwtFeatures;
using Sena.infraestructure.ServiciosEmail;
using System.Text;
using System.Collections.Generic;

namespace WebAPISena
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
            services.AddDbContext<AngeeContext>(opt => {
                opt.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
                //opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddMvc().AddNewtonsoftJson(
             options => {
                 options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
             });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddIdentity<Users, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 7;
                opt.Password.RequireDigit = false;

                opt.User.RequireUniqueEmail = true;

                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
                opt.Lockout.MaxFailedAccessAttempts = 3;
            })
            .AddEntityFrameworkStores<AngeeContext>()
            .AddDefaultTokenProviders();

            services.Configure<DataProtectionTokenProviderOptions>(opt =>
                opt.TokenLifespan = TimeSpan.FromHours(2));

            var jwtSettings = Configuration.GetSection("JwtSettings");
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
                    ValidAudience = jwtSettings.GetSection("validAudience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.GetSection("securityKey").Value))
                };
            });

            services.AddScoped<JwtHandler>();

            var emailConfig = Configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, EmailSender>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Angee API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                         {
                            {
                              new OpenApiSecurityScheme
                              {
                                Reference = new OpenApiReference
                                      {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer"
                                      },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header,

                            },
                            new List<string>()
                            }
                        });
            });

            //services.AddScoped<IRepositoryProduct, RepositoryProduct>();
            services.AddScoped(typeof(IRepositorio<Users>), typeof(RepositorioBase<Users>));
            services.AddScoped(typeof(IRepositorio<Producto>), typeof(RepositorioBase<Producto>));
            services.AddScoped<IProducts, ServicioProducto>();
            services.AddScoped(typeof(IRepositorio<Cliente>), typeof(RepositorioBase<Cliente>));
            services.AddTransient<IRepositorioClientes, RepositorioClientes>();
            services.AddScoped<IClientsService, ClientService>();
            services.AddScoped(typeof(IRepositorio<Inventario>), typeof(RepositorioBase<Inventario>));
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped(typeof(IRepositorio<Proveedor>), typeof(RepositorioBase<Proveedor>));
            services.AddScoped<IProveedorService, ProveedorService>();
            services.AddScoped(typeof(IRepositorio<Reserva>), typeof(RepositorioBase<Reserva>));
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped(typeof(IRepositorio<Empleado>), typeof(RepositorioBase<Empleado>));
            services.AddScoped<IEmployeService, EmployeService>();
            services.AddScoped(typeof(IRepositorio<Pedido>), typeof(RepositorioBase<Pedido>));
            services.AddScoped<IOrderService, OrderService>();


            services.AddControllers();
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPISena v1"));
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseCors(builder => {
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

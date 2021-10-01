using System;
using System.Reflection;
using AutoMapper;
using ErcasCollect.DataAccess;
using ErcasCollect.DataAccess.Repository;
using ErcasCollect.Domain.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MediatR;
using Newtonsoft.Json.Serialization;
using ErcasCollect.Commands.BillerCommand;
using ErcasCollect.PipelineBehaviour;
using FluentValidation.AspNetCore;
using ErcasCollect.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ErcasCollect.Helpers;
using System.IO;

namespace ErcasCollect
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
            //connection for containerize application (fix later)
            //var server = Configuration["DBServer"] ?? "143.198.171.116";
            //var port = Configuration["DBPort"] ?? "1433";
            //var user = Configuration["DBUser"] ?? "SA";
            //var password = Configuration["DBPassword"] ?? "Pa@@w0rd2019";
            //var database = Configuration["Database"] ?? "collect";

            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
            //    $"Server={server},{port};Initial Catalog={database};User Id={user};Password={password}"
            //));


            services.AddControllers();

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddMvc(opt =>
            {
                opt.Filters.Add<ValidationBehaviour>();



            })
                 .AddFluentValidation(config =>
                  {
                      config.RegisterValidatorsFromAssemblyContaining<Startup>();
                  });
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(CreateBillerCommand).GetTypeInfo().Assembly);
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISettlementRepository, SettlementRepository>();
            services.AddScoped<IPosRepository, PosRepository>();
            services.AddScoped<ITaxPayerRepository, TaxPayerRepository>();
            services.AddScoped<IBillerTinRepository, BillerTinRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IBillerBankRepository, BillerBankRepository>();
            services.AddScoped<IBillerRepository, BillerRepository>();
            services.AddScoped<IBatchRepository, BatchRepository>();
            services.AddScoped<ILevelOneRepository, LevelOneRepository>();
            services.AddScoped<ILevelTwoRepository, LevelTwoRepository>();
            services.AddScoped<IWebCallService, WebCallService>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<INibssEbills, NibssEbills>();
            services.AddScoped<IEbillsRemittance, EbillsRemittance>();
            services.AddScoped<IEbillsNotification, EbillsNotification>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.AddMvc().AddXmlSerializerFormatters();

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            //adding api authentication settings
            var responseCodeSection = Configuration.GetSection("ResponseCode");
            var endpoint = Configuration.GetSection("WebEndpoint");
            var nameConstant = Configuration.GetSection("NameConstant");
            services
                .Configure<ResponseCode>(responseCodeSection)
                .Configure<WebEndpoint>(endpoint)
                .Configure<NameConstant>(nameConstant);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ERCAS Collect",
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors("MyPolicy");
            app.UseRouting();

        

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Collect API");

            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //PrepMigration.PrepPopulation(app);
        }
    }
}

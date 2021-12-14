using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using System;

namespace Odata_1
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

            services.AddControllers().AddOData(option => option.Select().Filter().Count().OrderBy().Expand().SetMaxTop(1000).AddRouteComponents("odata",
              new SampleDataModel().GetEntityDataModel()));
            //.AddOData(opt =>
            //opt.AddRouteComponents("odata",
            //    new SampleDataModel().GetEntityDataModel()));

            // Configuration.Select().Expand().Filter().OrderBy().MaxTop(null).Count();

            services.AddDbContext<SampleDbContext>(options =>
            {
                options.UseSqlServer(
                    @"Server=LAPTOP-MF7SL61R;Database=sampleDB;Trusted_Connection=True;MultipleActiveResultSets=true");
            });

            #region Swagger

            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(string.Format(@"{0}\OdataSamplAPI.xml", System.AppDomain.CurrentDomain.BaseDirectory));
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Sample OData",
                });

                //var jwtSecurityScheme = new OpenApiSecurityScheme
                //{
                //    Scheme = "bearer",
                //    BearerFormat = "JWT",
                //    Name = "JWT Authentication",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.Http,
                //    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                //    Reference = new OpenApiReference
                //    {
                //        Id = JwtBearerDefaults.AuthenticationScheme,
                //        Type = ReferenceType.SecurityScheme
                //    }
                //};

                //c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                //c.AddSecurityRequirement(new OpenApiSecurityRequirement
                //    {
                //        { jwtSecurityScheme, Array.Empty<string>() }
                //    });
            });
            #endregion

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

            #region Swagger
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "BookStoreAPI");
            });
            #endregion

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;
using System.IO;
using Microsoft.EntityFrameworkCore;


namespace ChinmayeePolicy
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
            services.AddMvc();

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Chinmayee Policy API",
                    Description = "Web API for Policy",
                    Version = "v1",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Chinmayee",
                        Email = string.Empty,
                        Url = ""
                    },
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });


            // moved this from context.cs file
            /*
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql(@"Host=ec2-54-243-63-13.compute-1.amazonaws.com;Database=d46u65jgu6o7g0;Username=omdcyfxildwgvt;Password=6e5b3c77d3402669530985e7ed46aa6c5edbf441b588931b19b1769493207d3a;Use SSL Stream=True;Trust Server Certificate=True;SSL Mode=Require;");
            }
        }
        */
            var connection = @"Host=ec2-54-243-63-13.compute-1.amazonaws.com;Database=d46u65jgu6o7g0;Username=omdcyfxildwgvt;Password=6e5b3c77d3402669530985e7ed46aa6c5edbf441b588931b19b1769493207d3a;Use SSL Stream=True;Trust Server Certificate=True;SSL Mode=Require;";

            services.AddDbContext<ChinmayeePolicyContext>(options => options.UseNpgsql(connection));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Chinmayee Policy API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc();

        }
    }
}

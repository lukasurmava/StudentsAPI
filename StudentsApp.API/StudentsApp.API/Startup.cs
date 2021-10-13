using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using StudentsApp.Infrastructure.Abstractions;
using StudentsApp.Infrastructure.Concrete;
using StudentsApp.Infrastructure.Data;
using StudentsApp.Service.Abstractions;
using StudentsApp.Service.Concrete;

namespace StudentsApp.API
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
            services.AddControllers().AddNewtonsoftJson(option =>
            {
                option.SerializerSettings.DateFormatString = "dd/mm/yyyy";
            }
            );

            services.AddDbContext<StudentsDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:ConnectionString"]);
            });

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentService, StudentService>();

            services.AddSwaggerGen(action =>
            {
                action.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Students API",
                    Description = "Students API responsible for CRUD operations",
                    Contact = new OpenApiContact
                    {
                        Email = "surmava0@gmail.com",
                        Name = "Luka Surmava"
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Students API");
                options.RoutePrefix = string.Empty;
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
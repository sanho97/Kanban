using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Kanban.Model.Entities;
using Kanban.Model;
using Kanban.Service.Implements;
using Kanban.Model.Shared;
using Kanban.Model.Shared.Service;

namespace Kanban.Api
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
            var ConnectionString = Configuration.GetConnectionString("KanbanDb");

            services.AddDbContext<KanbanDBContext>(options =>
                {
                    options.UseSqlServer(ConnectionString);
                    options.UseLazyLoadingProxies(false);
                });

            var config = new AutoMapper.MapperConfiguration(c => { c.AddProfile(new MapProfile()); });

            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);

            services.AddScoped<IUnitOfWork, UnitOfWork.Repositories.UnitOfWork>();

            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IListService, ListService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IChecklistService, ChecklistService>();
            services.AddScoped<ITodoItemService, TodoItemService>();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    });
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

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

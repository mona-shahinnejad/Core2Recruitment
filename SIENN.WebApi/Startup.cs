using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SIENN.DbAccess;
using SIENN.Services.DTO;
using SIENN.Services.IServices;
using SIENN.Services.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace SIENN.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "SIENN Recruitment API"
                });
            });

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<UnitOfWork>();
            services.AddTransient<IUnitService, UnitService>();
            services.AddTransient<IProductTypeService, ProductTypeService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();

            services.AddMvc();

            services.AddDbContext<DatabaseContext>(item => item.UseSqlServer(Configuration.GetConnectionString("myconn")));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SIENN Recruitment API v1");
            });

            app.UseMvc();
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Pets.Application.AbsFactory;
using Pets.Application.Input.Commands.PetsContext;
using Pets.Application.Input.Commands.VaccineContext;
using Pets.Application.Input.Handlers.PetsContext;
using Pets.Application.Input.Handlers.VaccineContext;
using Pets.Application.Repositories.PetsContext;
using Pets.Application.Repositories.VaccineContext;
using Pets.Infrastructure.Factory;
using Pets.Infrastructure.Repositories.PetsContext;
using Pets.Infrastructure.Repositories.VaccineContext;

namespace Pets.API
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
            services.AddControllers();

            services.AddScoped<AbsDBFactory, SqlFactory>();
            services.AddTransient<IOwnerRepository, OwnerRepository>();
            services.AddTransient<IPetRepository, PetRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IOwnerPetsRepository, OwnerPetsRepository>();

            services.AddTransient<InsertOwnerHandler, InsertOwnerHandler>();
            services.AddTransient<InsertOwnerCommand, InsertOwnerCommand>();
            services.AddTransient<InsertPetHandler, InsertPetHandler>();
            services.AddTransient<InsertPetCommand, InsertPetCommand>();
            services.AddTransient<InsertCategoryHandler, InsertCategoryHandler>();
            services.AddTransient<InsertCategoryCommand, InsertCategoryCommand>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pets.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pets.API v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

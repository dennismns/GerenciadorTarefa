using Microsoft.OpenApi.Models;
using System.Text;
using webapi.Data;
using webapi.Services;

namespace webapi
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureService(IServiceCollection Services)
        {
            Services.AddControllers();
            Services.AddDbContext<DataContext>();

            Services.AddScoped<DataContext, DataContext>();

            Services.AddCors(optons =>
            {
                optons.AddPolicy("corsapp",
                    builder => builder.WithOrigins("*")
                .AllowAnyHeader()
                .AllowAnyMethod());
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            Services.AddEndpointsApiExplorer();
            Services.AddSwaggerGen();    
           

        }

        public void Configure(WebApplication app, IWebHostEnvironment webHostEnvironment)
        {
            DatabaseService.MigrationInitial(app);
            app.UseStaticFiles();
            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
               app.UseSwaggerUI();
            //}

            //app.UseHttpsRedirection();
            app.UseCors("corsapp");
            app.UseAuthorization();

            app.MapControllers();
        }

    }
}

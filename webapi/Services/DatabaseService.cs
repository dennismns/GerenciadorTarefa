using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;
using webapi.Data;

namespace webapi.Services
{
    public static class DatabaseService
    {

       

       public static void MigrationInitial(this IApplicationBuilder app)
        {
            using (var ServiceScope = app.ApplicationServices.CreateScope()) 
            {
                var serviceDb = ServiceScope.ServiceProvider
                   .GetService<DataContext>();

                serviceDb.Database.Migrate();
            };

               
        }
    }
}

using Company.Core.Repository;
using Company.Core.Services;
using Company.Repository;
using Company.Repository.Entities;
using Company.Services;
using Microsoft.EntityFrameworkCore;

namespace Company.Web.Api.Extension
{
    public static class ServiceExtentions
    {
        public static void RegisterServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IEmployeeService, EmployeeService>();
            serviceCollection.AddDbContext<EmployeeDbContext>(options => SqlServerDbContextOptionsExtensions.
            UseSqlServer(options, configuration.GetConnectionString("DBConnection")));
            serviceCollection.AddScoped<IEmployeeRepository, EmployeeRepository>();
            serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }
    }
}

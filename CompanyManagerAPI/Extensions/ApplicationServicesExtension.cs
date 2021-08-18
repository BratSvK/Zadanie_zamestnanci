
using CompanyManagerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyManagerAPI.Extensions
{
    public static class ApplicationServicesExtension
    {

        public static IServiceCollection ApplicationServices(this IServiceCollection service, IConfiguration config)
        {
            
            service.AddDbContext<DataContext>(options => {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
            

            return service;
        }
        
    }
}
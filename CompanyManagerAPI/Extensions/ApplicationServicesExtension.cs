
using CompanyManagerAPI.Data;
using CompanyManagerAPI.Helpers;
using CompanyManagerAPI.Interfaces;
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
            // adding automaper 
            // go and find profiles create inside the class 
            service.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            // all instances
            service.AddScoped<IEmployeeRepository, EmploeyeeRepository>();
            service.AddScoped<IFirmaRepository, FirmaRepository>();
            service.AddScoped<IDiviziaRepository, DiviziaRepository>();
            service.AddScoped<IProjektRepository, ProjektRepository>();
            service.AddScoped<IOddelenieRepository, OddelenieRepository>();




            service.AddDbContext<DataContext>(options => {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
            

            return service;
        }
        
    }
}
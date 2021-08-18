using Microsoft.EntityFrameworkCore;

namespace CompanyManagerAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }


        // here i will have all entities 
    }
}
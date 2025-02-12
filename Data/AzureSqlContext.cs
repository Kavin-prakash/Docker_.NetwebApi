
using AzuerSqApi.Model;
using Microsoft.EntityFrameworkCore;

namespace AzuerSqApi.Data
{
    public class AzureSqlContext:DbContext
    {
        public AzureSqlContext(DbContextOptions<AzureSqlContext>options) : base(options)
        {
            
            
        }

        public  DbSet<User> Users { get; set; }
    }
}

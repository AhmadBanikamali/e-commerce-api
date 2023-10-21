using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Common
{
    public interface IDatabaseContext
    { 
        
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        int SaveChanges();
    }
}

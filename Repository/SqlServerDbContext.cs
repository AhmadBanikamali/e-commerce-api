using Application.Common;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class SqlServerDbContext : IdentityDbContext<ApplicationUser>,IDatabaseContext
{
    public SqlServerDbContext(DbContextOptions options):base(options)
    {
        
    }

    public DbSet<Product> Product { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            builder.Entity(entityType.Name).Property<DateTime>("InsertTime").HasDefaultValue(DateTime.Now);
            builder.Entity(entityType.Name).Property<DateTime?>("UpdateTime");
            builder.Entity(entityType.Name).Property<DateTime?>("RemoveTime");
            builder.Entity(entityType.Name).Property<bool>("IsRemoved").HasDefaultValue(false);
        }

        builder.Entity<Product>()
            .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);

        builder.Entity<ProductDetail>()
            .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);

        builder.Entity<Guaranty>()
            .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);

        builder.Entity<Color>()
            .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);

        builder.Entity<Category>(entity =>
        {
            entity.HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);
            entity.HasKey(x => x.Name);
            entity.HasOne(x => x.ParentCategory)
                .WithMany(x => x.ChildCategories)
                .HasForeignKey(x => x.Name)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        });

        base.OnModelCreating(builder);
    }

    public override int SaveChanges()
    {
        var modifiedEntries = ChangeTracker.Entries()
            .Where(p => p.State == EntityState.Modified ||
                        p.State == EntityState.Added ||
                        p.State == EntityState.Deleted
            );
        foreach (var item in modifiedEntries)
        {
            var entityType = item.Context.Model.FindEntityType(item.Entity.GetType());

            if (entityType == null)
                continue;

            if (item.State == EntityState.Added)
            {
                item.Property("InsertTime").CurrentValue = DateTime.Now;
            }

            if (item.State == EntityState.Modified)
            {
                item.Property("UpdateTime").CurrentValue = DateTime.Now;
            }

            if (item.State == EntityState.Deleted)
            {
                item.Property("RemoveTime").CurrentValue = DateTime.Now;
                item.Property("IsRemoved").CurrentValue = true;
                item.State = EntityState.Modified;
            }
        }

        return base.SaveChanges();
    }
}
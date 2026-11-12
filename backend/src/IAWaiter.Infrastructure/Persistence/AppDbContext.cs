using IAWaiter.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IAWaiter.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Restaurant> Restaurants => Set<Restaurant>();

    public DbSet<Branch> Branches => Set<Branch>();

    public DbSet<Table> Tables => Set<Table>();

    public DbSet<Category> Categories => Set<Category>();

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(x => x.BusinessName)
                .HasMaxLength(250);

            entity.Property(x => x.Ruc)
                .HasMaxLength(11);
        });

        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.HasOne(x => x.Restaurant)
                .WithMany(x => x.Branches)
                .HasForeignKey(x => x.RestaurantId);
        });

        modelBuilder.Entity<Table>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(x => x.QrCode)
                .HasMaxLength(500);

            entity.HasOne(x => x.Branch)
                .WithMany(x => x.Tables)
                .HasForeignKey(x => x.BranchId);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(x => x.Description)
                .HasMaxLength(500);

            entity.HasOne(x => x.Restaurant)
                .WithMany(x => x.Categories)
                .HasForeignKey(x => x.RestaurantId);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(x => x.Description)
                .HasMaxLength(1000);

            entity.Property(x => x.Price)
                .HasColumnType("numeric(10,2)");

            entity.Property(x => x.ImageUrl)
                .HasMaxLength(500);

            entity.HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryId);
        });
    }
}
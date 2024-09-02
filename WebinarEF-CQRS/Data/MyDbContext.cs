using Microsoft.EntityFrameworkCore;
using WebinarEFCQRS.Domain;
using WebinarEFCQRS.Features.Customer.Dtos;
using WebinarEFCQRS.Features.Order.Dtos;
using WebinarEFCQRS.Features.OrderItem.Dtos;

namespace WebinarEFCQRS.Data;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=./Data/DataWebinarEF.db;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().ToTable("Customers");
        modelBuilder.Entity<Order>().ToTable("Orders");
        modelBuilder.Entity<OrderItem>().ToTable("OrderItems");
    }
}
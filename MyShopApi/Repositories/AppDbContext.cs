using Microsoft.EntityFrameworkCore;
using MyShopApi.Entities;

namespace MyShopApi.Repositories;

public class AppDbContext : DbContext
{
    public DbSet<Customer>? Customers { get; set; }
    public DbSet<Product>? Products { get; set; }
    public DbSet<Purchase>? Purchases { get; set; }
    public DbSet<PurchaseDetail>? PurchaseDetails { get; set; }

    protected AppDbContext() { }

    public AppDbContext(DbContextOptions options) : base(options) { }
}
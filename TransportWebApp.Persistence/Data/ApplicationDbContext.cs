using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TransportWebApp.Domain.Entities;

namespace TransportWebApp.Persistence.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Good> Goods => Set<Good>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<Vehicle> Vehicles => Set<Vehicle>();
    public DbSet<Driver> Drivers => Set<Driver>();
    public DbSet<Delivery> Deliveries => Set<Delivery>();
    public DbSet<Invoice> Invoices => Set<Invoice>();
    public DbSet<InvoiceLine> InvoiceLines => Set<InvoiceLine>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        base.OnModelCreating(b);

        // Owned value objects
        b.Entity<Client>().OwnsOne(c => c.BillingAddress);
        b.Entity<Client>().OwnsOne(c => c.DefaultPickupAddress);

        b.Entity<Order>().OwnsOne(o => o.PickupAddress);
        b.Entity<Order>().OwnsOne(o => o.DeliveryAddress);

        // Unique numbers
        b.Entity<Order>().HasIndex(o => o.OrderNumber).IsUnique();
        b.Entity<Invoice>().HasIndex(i => i.InvoiceNumber).IsUnique();
        b.Entity<Vehicle>().HasIndex(v => v.PlateNumber).IsUnique();

        // Relationships
        b.Entity<Order>()
            .HasOne(o => o.Client)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

        b.Entity<OrderItem>()
            .HasOne(oi => oi.Order)
            .WithMany(o => o.Items)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        b.Entity<OrderItem>()
            .HasOne(oi => oi.Good)
            .WithMany()
            .HasForeignKey(oi => oi.GoodId)
            .OnDelete(DeleteBehavior.Restrict);

        b.Entity<Delivery>()
            .HasOne(d => d.Order)
            .WithMany(o => o.Deliveries)
            .HasForeignKey(d => d.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        b.Entity<Delivery>()
            .HasOne(d => d.Vehicle)
            .WithMany(v => v.Deliveries)
            .HasForeignKey(d => d.VehicleId)
            .OnDelete(DeleteBehavior.SetNull);

        b.Entity<Delivery>()
            .HasOne(d => d.Driver)
            .WithMany(dr => dr.Deliveries)
            .HasForeignKey(d => d.DriverId)
            .OnDelete(DeleteBehavior.SetNull);

        b.Entity<Invoice>()
            .HasOne(i => i.Client)
            .WithMany(c => c.Invoices)
            .HasForeignKey(i => i.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

        b.Entity<Invoice>()
            .HasOne(i => i.Order)
            .WithOne(o => o.Invoice)
            .HasForeignKey<Invoice>(i => i.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

        b.Entity<InvoiceLine>()
            .HasOne(l => l.Invoice)
            .WithMany(i => i.Lines)
            .HasForeignKey(l => l.InvoiceId)
            .OnDelete(DeleteBehavior.Cascade);

        // InvoiceLine
        b.Entity<InvoiceLine>().Property(p => p.UnitPrice).HasColumnType("decimal(18,2)");
        b.Entity<InvoiceLine>().Property(p => p.LineTotal).HasColumnType("decimal(18,2)");

        // OrderItem
        b.Entity<OrderItem>().Property(p => p.UnitPrice).HasColumnType("decimal(18,2)");
        b.Entity<OrderItem>().Property(p => p.LineTotal).HasColumnType("decimal(18,2)");

        // Good (optional default unit price)
        b.Entity<Good>().Property(p => p.UnitPrice).HasColumnType("decimal(18,2)");

        // Invoice totals
        b.Entity<Invoice>().Property(p => p.Subtotal).HasColumnType("decimal(18,2)");
        b.Entity<Invoice>().Property(p => p.TaxAmount).HasColumnType("decimal(18,2)");
        b.Entity<Invoice>().Property(p => p.Total).HasColumnType("decimal(18,2)");

        // TaxRate (store as percentage, e.g. 0.20 for 20%)
        b.Entity<Invoice>().Property(p => p.TaxRate).HasColumnType("decimal(5,4)");
    }
}

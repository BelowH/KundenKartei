using KundenKartei.Domain;
using Microsoft.EntityFrameworkCore;

namespace KundenKartei.Database;

public class AppDbContext : DbContext
{
    
    public DbSet<Address> Addresses { get; set; }
    
    public DbSet<Contact> Contacts { get; set; }
    
    public DbSet<Customer> Customers { get; set; }
    
    public DbSet<Event> Events { get; set; }
    
    public DbSet<EventParticipant> EventParticipants { get; set; }
    
    public DbSet<Product> Products { get; set; }
    
    public DbSet<ProductColor> ProductColors { get; set; }
    
    public DbSet<ProductSize> ProductSizes { get; set; }
    
    public DbSet<ProductSale> ProductSales { get; set; }
    
    public DbSet<User> Users { get; set; }
    
    private ProductSize[] _seededSizes =
    [
        new(){Name = "S", ProductSizeId = "3336b5ba-c8de-4c7e-ad8e-bfb0b3b6cba1"},
        new(){Name = "S-M", ProductSizeId = "5c48d66c-eae7-49ab-8646-005d67346497"},
        new(){Name = "M", ProductSizeId = "a1ab8745-9b96-467a-87f4-6d7e32b942be"},
        new(){Name = "M-L", ProductSizeId = "bdd45e25-00f2-45f3-bc2c-5714e3b2aaf5"},
        new(){Name = "L", ProductSizeId = "d47e6f22-c1b1-4068-b027-4d5b0441844b"},
        new(){Name = "schmal", ProductSizeId = "aad80c4a-7745-4ca6-aa28-c158f683c70f"},
        new(){Name = "breit", ProductSizeId = "45bac62c-bfed-47b1-91ca-ee1c12f576a5"}
    ];

    private ProductColor[] _seededColors =
    [
        new ProductColor(){Name = "braun", Hex = "#5a270f", ProductColorId = "aa49baa0-ec68-42de-9381-9a6a03c15982"},
        new ProductColor(){Name = "schwarz", Hex = "#000000", ProductColorId = "4b60cb8a-d619-4ea8-8f70-68a1ffa5f605"},
    ];


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductSize>()
            .HasOne(p => p.Product)
            .WithMany(p => p.Sizes)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ProductColor>()
            .HasOne(p => p.Product)
            .WithMany(p => p.Colors)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Product>();

        modelBuilder.Entity<Address>()
            .HasIndex(a => new { a.EntityType, a.EntityId });

        modelBuilder.Entity<Event>()
            .HasOne(e => e.Organizer)
            .WithMany(u => u.Events)
            .HasForeignKey(e => e.OrganizerId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Event>()
            .HasOne(e => e.Address)
            .WithOne()
            .HasForeignKey<Address>(a => a.EntityId)
            .HasPrincipalKey<Event>(e => e.EventId)
            .OnDelete(DeleteBehavior.Cascade);
            
        modelBuilder.Entity<Customer>()
            .HasOne(c => c.Address)
            .WithOne()
            .HasForeignKey<Address>(a => a.EntityId)
            .HasPrincipalKey<Customer>(c => c.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Customer>()
            .HasOne(c => c.Contact)
            .WithOne()
            .HasForeignKey<Contact>(c => c.ContactId)
            .HasPrincipalKey<Customer>(c => c.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);
            
        modelBuilder.Entity<EventParticipant>()
            .HasOne(e => e.Customer)
            .WithMany(c => c.Participates)
            .HasForeignKey(e => e.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<EventParticipant>()
            .HasOne(e => e.Event)
            .WithMany(e => e.Participants)
            .HasForeignKey(e => e.EventId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<ProductSale>()
            .HasOne(c => c.Customer)
            .WithMany(c => c.BoughtItems)
            .HasForeignKey(s => s.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<ProductSale>()
            .HasOne(c => c.Product)
            .WithMany(p => p.Sales)
            .HasForeignKey(s => s.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<ProductSale>()
            .HasOne(c => c.Seller)
            .WithMany(u => u.Sales)
            .HasForeignKey(s => s.SellerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProductSale>()
            .HasOne(s => s.Color)
            .WithOne()
            .HasForeignKey<ProductColor>(c => c.ProductColorId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<ProductSale>()
            .HasOne(s => s.Size)
            .WithOne()
            .HasForeignKey<ProductSize>(c => c.ProductSizeId)
            .OnDelete(DeleteBehavior.Restrict);

        //modelBuilder.Entity<ProductSize>().HasData(_seededSizes);
        //modelBuilder.Entity<ProductColor>().HasData(_seededColors);
    }
    
    
    
}
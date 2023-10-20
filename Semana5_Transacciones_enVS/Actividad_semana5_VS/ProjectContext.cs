using Actividad_semana4_VS.Model;
using Microsoft.EntityFrameworkCore;

namespace Actividad_semana4_VS
{
    public class ProjectContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Client> clientsInt = new List<Client>();
            clientsInt.Add(new Client() { ClientId = 1, Identification = "m1", Name = "Juan", AvailableBalance = 0.15 });
            clientsInt.Add(new Client() { ClientId = 2, Identification = "m2", Name = "Pedro", AvailableBalance = 5.5 });
            clientsInt.Add(new Client() { ClientId = 3, Identification = "m3", Name = "Andres", AvailableBalance = 900.2 });

            modelBuilder.Entity<Client>(client =>
            {
                client.ToTable("Client");
                client.HasKey(p => p.ClientId);
                client.Property(p => p.Identification).HasMaxLength(32);
                client.Property(p => p.Name).HasMaxLength(50);
                client.Property(p => p.AvailableBalance);


                client.HasData(clientsInt);

            });

            List<Product> productsInt = new List<Product>();
            productsInt.Add(new Product() { ProductId = 11, ProductCode = 111, ProductName = "Pencils", ProductValue = 0.3 });
            productsInt.Add(new Product() { ProductId = 12, ProductCode = 222, ProductName = "Drafts", ProductValue = 0.4 });
            productsInt.Add(new Product() { ProductId = 13, ProductCode = 333, ProductName = "Chairs", ProductValue = 10 });

            modelBuilder.Entity<Product>(product =>
            {
                product.ToTable("Product");
                product.HasKey(p => p.ProductId);
                product.Property(p => p.ProductCode).HasMaxLength(8);
                product.Property(p => p.ProductName).HasMaxLength(20);
                product.Property(p => p.ProductValue);
                product.HasData(productsInt);
            });

            List<Order> ordersInt = new List<Order>();
            ordersInt.Add(new Order() { OrderId = 12345, Units = 10, ProductValue =  10, ClientId = 3, ProductId = 13});

            modelBuilder.Entity<Order>(order =>
            {
                order.ToTable("Order");
                order.HasKey(p => p.OrderId);
                order.Property(p => p.Units).IsRequired();
                order.Property(p => p.ProductValue).IsRequired();
                order.Property(p => p.Total).HasComputedColumnSql("[Units]*[ProductValue]");


                order.HasOne(p => p.Product)
                .WithMany(b => b.Orders)
                .HasForeignKey(p => p.ProductId);
                order.HasOne(p => p.Client)
                .WithMany(b => b.Orders)
                .HasForeignKey(p => p.ClientId);

                order.Property(p => p.ProductId);
                order.Property(p => p.ClientId);

                order.HasData(ordersInt);
            });
        }

    }
}

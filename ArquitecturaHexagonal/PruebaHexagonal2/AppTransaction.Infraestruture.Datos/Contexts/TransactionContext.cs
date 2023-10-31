using Microsoft.EntityFrameworkCore;
using AppTransaction.Dominio;

namespace AppTransaction.Infraestruture.Datos.Contexts
{
    public class TransactionContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source=DESKTOP-3ECFEEU\\INSTANCIA2; Initial Catalog=ProjectTransactionHexagonal; user=sa;password=migue990622;TrustServerCertificate=True");
        }
    }
}

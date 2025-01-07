using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(18,4)"); 
            });

            modelBuilder.Entity<Transactions>()
                    .Property(t => t.TransactionAmount).HasPrecision(18, 4);
        }
        public DbSet<Users> User { get; set; }
        public DbSet<Files> StoredFile { get; set; }

        public DbSet<Transactions> Transaction { get; set; }
    }
}

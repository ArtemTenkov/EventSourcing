using Microsoft.EntityFrameworkCore;

namespace Balance.Infrastructure.Models
{
    public class QueryContext : DbContext
    {        
        public virtual DbSet<Transaction> Transaction { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13;Database=Db;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TransactionDateTime).HasColumnType("datetime");

                entity.Property(e => e.TransactionStatusCode)
                    .IsRequired()
                    .HasColumnType("char(2)")
                    .HasDefaultValueSql("('PR')");
            });
        }
    }
}

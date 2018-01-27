using Microsoft.EntityFrameworkCore;

namespace Balance.Infrastructure.Models
{
    public partial class EventSourcingContext : DbContext
    {
        public virtual DbSet<EventSourcing> EventSourcing { get; set; }      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13;Database=Db;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventSourcing>(entity =>
            {
                entity.HasIndex(e => e.AggregateId)
                    .HasName("Idx_Events_AggregateId");

                entity.HasIndex(e => e.Dispatched)
                    .HasName("Idx_Events_Dispatched");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AggregateType)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Event).IsRequired();

                entity.Property(e => e.Metadata).IsRequired();
            });            
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace NetDemo.Models
{
    public partial class DemoContext : DbContext
    {
        public DemoContext()
        {
        }

        public DemoContext(DbContextOptions<DemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Training> Training { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(100);

                entity.Property(e => e.Address)
                    .HasMaxLength(250);

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(100);

                entity.Property(e => e.Age);

                entity.Property(e => e.SecurityToken);

                entity.Property(e => e.IsActive);
                
            });

            modelBuilder.Entity<Training>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Location).HasMaxLength(250);

                entity.Property(e => e.IsActive);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Training)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_Training_Person");
            });
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace NetDemo.Models
{
    public partial class demoContext : DbContext
    {
        public demoContext()
        {
        }

        public demoContext(DbContextOptions<demoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Training> Training { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source = DESKTOP-LMICV0L\\SQLEXPRESS; Initial Catalog = demo; Integrated Security = True; Connect Timeout=30");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Training>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Training)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_Training_Person");
            });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NetDemo.Models2.Models
{
    public partial class CGQA_621144616Context : DbContext
    {
        public CGQA_621144616Context()
        {
        }

        public CGQA_621144616Context(DbContextOptions<CGQA_621144616Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AlertGroup> AlertGroup { get; set; }
        public virtual DbSet<MainItemCardinality> MainItemCardinality { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:hln7ybc6ap.database.windows.net,1433;Initial Catalog=CGQA_621144616;Persist Security Info=False;User ID=StackifyStaff;Password=999vk$5$JUQ2U65F;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=60;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<AlertGroup>(entity =>
            {
                entity.HasIndex(e => e.EndedAt);

                entity.HasIndex(e => new { e.EndedAt, e.MonitorId })
                    .HasName("IX_AlertGroup_Monitor_MonitorId");
            });

            modelBuilder.Entity<MainItemCardinality>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PK_Group");

                entity.ToTable("MainItemCardinality", "WorkList");

                entity.Property(e => e.AppEnvId)
                    .IsRequired()
                    .HasColumnName("AppEnvID")
                    .HasMaxLength(200);

                entity.Property(e => e.AppName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.AverageTime).HasColumnType("decimal(18, 10)");

                entity.Property(e => e.CallCount).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.ItemTypeId).HasDefaultValueSql("((1))");

                entity.Property(e => e.RequestCount).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.TotalTime).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.TypeDetail)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UrlName)
                    .IsRequired()
                    .HasMaxLength(500);
            });
        }
    }
}

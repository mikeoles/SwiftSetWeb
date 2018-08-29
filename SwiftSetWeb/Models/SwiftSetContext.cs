using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SwiftSetWeb.Models
{
    public partial class SwiftSetContext : DbContext
    {
        public virtual DbSet<Exercises> Exercises { get; set; }
        public virtual DbSet<SortingCategory> SortingCategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source =.; Initial Catalog = SwiftSet; Persist Security Info = True; User ID = SwiftSetUser; Password = sspassword!; MultipleActiveResultSets = True; Application Name = EntityFramework");
            }
        }

        public SwiftSetContext(DbContextOptions<SwiftSetContext> options): base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercises>(entity =>
            {
                entity.ToTable("exercises");

                entity.Property(e => e.Id)
                    .HasColumnName("_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Angle).HasColumnType("text");

                entity.Property(e => e.Difficulty).HasDefaultValueSql("((1))");

                entity.Property(e => e.Eliminated).HasDefaultValueSql("((0))");

                entity.Property(e => e.Equipment).HasColumnType("text");

                entity.Property(e => e.Grip).HasColumnType("text");

                entity.Property(e => e.Joint)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('Isolation')");

                entity.Property(e => e.Movement).HasColumnType("text");

                entity.Property(e => e.Name).HasColumnType("text");

                entity.Property(e => e.Primary).HasColumnType("text");

                entity.Property(e => e.Sport).HasColumnType("text");

                entity.Property(e => e.Stability).HasDefaultValueSql("((0))");

                entity.Property(e => e.Tempo)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('Normal')");

                entity.Property(e => e.Unilateral).HasDefaultValueSql("((-1))");

                entity.Property(e => e.Url).HasColumnType("text");
            });

            modelBuilder.Entity<SortingCategory>(entity =>
            {
                entity.ToTable("sortingCategory");

                entity.Property(e => e.Id).HasColumnName("_id");

                entity.Property(e => e.ExerciseColumnName).HasMaxLength(50);

                entity.Property(e => e.Name).HasColumnType("nchar(50)");

                entity.Property(e => e.SortBy).HasMaxLength(50);
            });
        }
    }
}

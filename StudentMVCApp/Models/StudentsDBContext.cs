using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace StudentMVCApp.Models
{
    public partial class StudentsDBContext : DbContext
    {
        public StudentsDBContext()
        {
        }

        public StudentsDBContext(DbContextOptions<StudentsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StudentTable> StudentTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=.\\SQLExpress; Database=StudentsDB; Trusted_Connection=True;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentTable>(entity =>
            {
                entity.ToTable("StudentTable");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

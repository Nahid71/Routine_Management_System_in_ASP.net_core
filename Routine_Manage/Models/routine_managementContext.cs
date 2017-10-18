using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Routine_Manage.Models
{
    public partial class routine_managementContext : DbContext
    {
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<ClaSub> ClaSub { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<ClassRoutine> ClassRoutine { get; set; }
        public virtual DbSet<ExamRoutine> ExamRoutine { get; set; }
        public virtual DbSet<Registry> Registry { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }

       public routine_managementContext(DbContextOptions<routine_managementContext> options)
              : base(options)
        { }

        internal static Task<string> ToListAsync()
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ClaSub>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CStage)
                    .HasColumnName("C_stage")
                    .HasMaxLength(50);

                entity.Property(e => e.SCode).HasColumnName("S_code");

                entity.HasOne(d => d.CStageNavigation)
                    .WithMany(p => p.ClaSub)
                    .HasForeignKey(d => d.CStage)
                    .HasConstraintName("FK_ClaSub_Class");

                entity.HasOne(d => d.SCodeNavigation)
                    .WithMany(p => p.ClaSub)
                    .HasForeignKey(d => d.SCode)
                    .HasConstraintName("FK_ClaSub_Subject");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.CStage)
                    .HasName("PK_Class");

                entity.Property(e => e.CStage)
                    .HasColumnName("C_stage")
                    .HasMaxLength(50);

                entity.Property(e => e.CType)
                    .IsRequired()
                    .HasColumnName("C_type")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ClassRoutine>(entity =>
            {
                entity.HasKey(e => e.Serial)
                    .HasName("PK_ClassRoutine");

                entity.Property(e => e.Serial).ValueGeneratedNever();

                entity.Property(e => e.CStage)
                    .IsRequired()
                    .HasColumnName("C_stage")
                    .HasMaxLength(50);

                entity.Property(e => e.Day).HasMaxLength(50);

                entity.Property(e => e.RoomNo).HasColumnName("Room_no");

                entity.Property(e => e.SCode).HasColumnName("S_code");

                entity.HasOne(d => d.CStageNavigation)
                    .WithMany(p => p.ClassRoutine)
                    .HasForeignKey(d => d.CStage)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ClassRoutine_Class");

                entity.HasOne(d => d.RoomNoNavigation)
                    .WithMany(p => p.ClassRoutine)
                    .HasForeignKey(d => d.RoomNo)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ClassRoutine_Room1");

                entity.HasOne(d => d.SCodeNavigation)
                    .WithMany(p => p.ClassRoutine)
                    .HasForeignKey(d => d.SCode)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ClassRoutine_Subject");
            });

            modelBuilder.Entity<ExamRoutine>(entity =>
            {
                entity.HasKey(e => e.Serial)
                    .HasName("PK_ExamRoutine");

                entity.Property(e => e.Serial).ValueGeneratedNever();

                entity.Property(e => e.CStage)
                    .IsRequired()
                    .HasColumnName("C_stage")
                    .HasMaxLength(50);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.RoomNo).HasColumnName("Room_no");

                entity.Property(e => e.SCode).HasColumnName("S_code");

                entity.HasOne(d => d.CStageNavigation)
                    .WithMany(p => p.ExamRoutine)
                    .HasForeignKey(d => d.CStage)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ExamRoutine_Class");

                entity.HasOne(d => d.RoomNoNavigation)
                    .WithMany(p => p.ExamRoutine)
                    .HasForeignKey(d => d.RoomNo)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ExamRoutine_Room1");

                entity.HasOne(d => d.SCodeNavigation)
                    .WithMany(p => p.ExamRoutine)
                    .HasForeignKey(d => d.SCode)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ExamRoutine_Subject");
            });

            modelBuilder.Entity<Registry>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.RoomNo)
                    .HasName("PK_Room");

                entity.Property(e => e.RoomNo)
                    .HasColumnName("Room_no")
                    .ValueGeneratedNever();

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Class).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.ClassNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.Class)
                    .HasConstraintName("FK_Student_Class");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.SCode)
                    .HasName("PK_Subject");

                entity.Property(e => e.SCode)
                    .HasColumnName("S_code")
                    .ValueGeneratedNever();

                entity.Property(e => e.SName)
                    .IsRequired()
                    .HasColumnName("S_name")
                    .HasMaxLength(50);

                entity.Property(e => e.SType)
                    .HasColumnName("S_type")
                    .HasMaxLength(50);

                entity.Property(e => e.TId).HasColumnName("T_id");

                entity.HasOne(d => d.T)
                    .WithMany(p => p.Subject)
                    .HasForeignKey(d => d.TId)
                    .HasConstraintName("FK_Subject_Teacher");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
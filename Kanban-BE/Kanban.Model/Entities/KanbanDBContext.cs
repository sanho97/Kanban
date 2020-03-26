using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Kanban.Model.Entities
{
    public partial class KanbanDBContext : DbContext
    {
        public KanbanDBContext()
        {
        }

        public KanbanDBContext(DbContextOptions<KanbanDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Checklist> Checklist { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<List> List { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<TodoItem> TodoItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=kanbandb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Checklist>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(500);

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Checklist)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ThingsTodo_Task");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(500);
            });

            modelBuilder.Entity<List>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.AssignedEmployee)
                    .WithMany(p => p.TaskAssignedEmployee)
                    .HasForeignKey(d => d.AssignedEmployeeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Task_Employee");

                entity.HasOne(d => d.List)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.ListId)
                    .HasConstraintName("FK_Task_TaskList");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.TaskOwner)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK_Task_Owner");
            });

            modelBuilder.Entity<TodoItem>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(500);

                entity.HasOne(d => d.Checklist)
                    .WithMany(p => p.TodoItem)
                    .HasForeignKey(d => d.ChecklistId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Checklist_ThingsTodo");
            });
        }
    }
}

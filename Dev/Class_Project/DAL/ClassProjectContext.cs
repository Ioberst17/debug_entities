namespace Class_Project.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Class_Project.Models;

    public partial class ClassProjectContext : DbContext
    {
        public ClassProjectContext()
            : base("name=ClassProjectContext")
        {
        }

        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Athlete> Athletes { get; set; }
        public virtual DbSet<Coach> Coaches { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Athlete>()
                .HasMany(e => e.Coaches)
                .WithRequired(e => e.Athlete1)
                .HasForeignKey(e => e.Athlete)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Coach>()
                .HasMany(e => e.Administrators)
                .WithRequired(e => e.Coach1)
                .HasForeignKey(e => e.Coach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Result>()
                .HasMany(e => e.Administrators)
                .WithRequired(e => e.Result)
                .HasForeignKey(e => e.ResultAth)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Result>()
                .HasMany(e => e.Athletes)
                .WithRequired(e => e.Result)
                .HasForeignKey(e => e.AthResults)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Result>()
                .HasMany(e => e.Coaches)
                .WithRequired(e => e.Result)
                .HasForeignKey(e => e.AthlResult)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Result>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Result)
                .HasForeignKey(e => e.AthResult)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Administrators)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserInfo)
                .WillCascadeOnDelete(false);
        }
    }
}

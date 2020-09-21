using blogBukov.Domain.Model;
using blogBukov.Domain.Model.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogBukov.Domain.DB
{
    public class BlogDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {

        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }

        public override DbSet<User> Users { get; set; }

        public DbSet<Employee> Employees { get; private set; }

        public DbSet<BlogPost> BlogPost { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(x =>
            {
                x.HasOne(y => y.Employee)
                .WithOne()
                .HasForeignKey<User>("EmployeeId")
                .IsRequired(true);
                x.HasIndex("EmployeeId").IsUnique(true);
            });

            #region Employee
            modelBuilder.Entity<Employee>(b =>
            {
                b.ToTable("Employees");
                EntityId(b);
                b.Property(x => x.FirstName)
                    .HasColumnName("FirstName")
                    .IsRequired();
                b.Property(x => x.Surname)
                    .HasColumnName("Surname")
                    .IsRequired();
                b.Property(x => x.Address)
                    .HasColumnName("Address");
                b.Ignore(x => x.FirstName);
            });
            #endregion

            #region BlogPost
            modelBuilder.Entity<BlogPost>(b =>
            {
                b.ToTable("BlogPosts");
                EntityId(b);
                b.Property(x => x.Created)
                    .HasColumnName("Created")
                    .IsRequired();
                b.Property(x => x.Title)
                    .HasColumnName("Title")
                    .IsRequired();
                b.Property(x => x.Data)
                    .HasColumnName("Data")
                    .IsRequired();
                b.HasOne(x => x.Owner)
                    .WithMany()
                    .IsRequired();
            });
            #endregion
        }

        private static void EntityId<TEntity>(EntityTypeBuilder<TEntity> builder)
            where TEntity : Entity
        {
            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired();
            builder.HasKey(x => x.Id)
                .HasAnnotation("Npgsql:Serial", true);
        }
    }
}

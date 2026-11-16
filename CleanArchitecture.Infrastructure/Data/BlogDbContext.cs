using CleanArchitecture.Domain.Enitites;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Data
{
    public class BlogDbContext : DbContext, IBlogDbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
      
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Blog>()
                    .OwnsOne(b => b.Name, name =>
                    {
                        name.Property(n => n.Value)
                            .HasColumnName("Name");
                    });
                modelBuilder.Entity<Blog>()
                    .HasMany(b => b.Comments)
                    .WithOne()
                    .HasForeignKey(c => c.BlogId);
            base.OnModelCreating(modelBuilder);
            }
        public DbSet<Comment> Comments { get; set; }
    }

    }


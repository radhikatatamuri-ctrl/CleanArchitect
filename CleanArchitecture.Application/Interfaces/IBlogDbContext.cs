using CleanArchitecture.Domain.Enitites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IBlogDbContext
    {
        DbSet<Blog> Blogs { get; }

        DbSet<AuditLog> AuditLogs { get; }

        Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default);
    }
}

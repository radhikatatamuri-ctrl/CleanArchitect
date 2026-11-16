using CleanArchitecture.Application.Features.Blogs.Events;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Enitites;
using MediatR;
using Microsoft.Extensions.Logging;

public class BlogAuditEventHandler
    : INotificationHandler<BlogCreatedEvent>
{
    //private readonly BlogDbContext _blogDbContext;
    private readonly IBlogDbContext _blogDbContext;
    private readonly ILogger<BlogAuditEventHandler> _logger;

    public BlogAuditEventHandler(
        IBlogDbContext blogDbContext,
        ILogger<BlogAuditEventHandler> logger)
    {
        _blogDbContext = blogDbContext;
        _logger = logger;
    }

    public async Task Handle(
    BlogCreatedEvent notification,
    CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Audit Entry Added For Blog: {Name}",
            notification.BlogName);

        var auditLog = new AuditLog
        {
            EventName = "BlogCreated",
            Description = $"Blog Created : {notification.BlogId} - {notification.BlogName}",
            CreatedDate = DateTime.UtcNow
        };

        await _blogDbContext.AuditLogs.AddAsync(auditLog);

        await _blogDbContext.SaveChangesAsync();
    }
}
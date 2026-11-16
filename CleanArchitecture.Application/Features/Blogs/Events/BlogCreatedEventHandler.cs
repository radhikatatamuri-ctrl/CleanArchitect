using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Blogs.Events;

public class BlogCreatedEventHandler
    : INotificationHandler<BlogCreatedEvent>
{
    private readonly ILogger<BlogCreatedEventHandler> _logger;

    public BlogCreatedEventHandler(
        ILogger<BlogCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public async Task Handle(
        BlogCreatedEvent notification,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Blog Created : {BlogId} - {BlogName}",
            notification.BlogId,
            notification.BlogName);

        await Task.CompletedTask;
    }
}
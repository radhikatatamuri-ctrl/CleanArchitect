using CleanArchitecture.Application.Features.Blogs.Events;
using CleanArchitecture.Domain.Interface;
using MediatR;

public class BlogSnsEventHandler
    : INotificationHandler<BlogCreatedEvent>
{
    private readonly ISnsService _snsService;

    public BlogSnsEventHandler(ISnsService snsService)
    {
        _snsService = snsService;
    }

    public async Task Handle(
        BlogCreatedEvent notification,
        CancellationToken cancellationToken)
    {
        await _snsService.PublishAsync(
            $"Hurray !! Blog Created successfully and the BlogName : {notification.BlogName}");
    }
}
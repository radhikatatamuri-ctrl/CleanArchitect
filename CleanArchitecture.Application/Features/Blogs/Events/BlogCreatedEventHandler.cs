using MediatR;

namespace CleanArchitecture.Application.Features.Blogs.Events;

public class BlogCreatedEventHandler
    : INotificationHandler<BlogCreatedEvent>
{
    public async Task Handle(
        BlogCreatedEvent notification,
        CancellationToken cancellationToken)
    {
      //  Console.WriteLine($"Blog Created : {notification.BlogId} - {notification.BlogName}");
        System.Diagnostics.Debug.WriteLine(
    $"Blog Created : {notification.BlogId} - {notification.BlogName}");

        await Task.CompletedTask;
    }
}

using MediatR;

namespace CleanArchitecture.Application.Features.Blogs.Events;

public record BlogCreatedEvent(
    int BlogId,
    string BlogName)
    : INotification;
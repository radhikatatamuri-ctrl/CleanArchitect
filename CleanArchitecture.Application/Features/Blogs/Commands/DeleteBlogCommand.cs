using MediatR;

public record DeleteBlogCommand(int Id)
    : IRequest<int>;
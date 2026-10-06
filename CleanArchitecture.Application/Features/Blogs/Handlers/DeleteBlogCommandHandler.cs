using CleanArchitecture.Domain.Interface;
using MediatR;

public class DeleteBlogCommandHandler
    : IRequestHandler<DeleteBlogCommand, int>
{
    private readonly IBlogRepository _repository;

    public DeleteBlogCommandHandler(
        IBlogRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(
        DeleteBlogCommand request,
        CancellationToken cancellationToken)
    {
        return await _repository.DeleteAsync(request.Id);
    }
}
using CleanArchitecture.Domain.Enitites;
using CleanArchitecture.Domain.Interface;
using MediatR;

namespace CleanArchitecture.Application.Features.Blogs.Queries;

public class GetBlogByIdQueryHandler
    : IRequestHandler<GetBlogByIdQuery, Blog>
{
    private readonly IBlogRepository _repository;

    public GetBlogByIdQueryHandler(
        IBlogRepository repository)
    {
        _repository = repository;
    }

    public async Task<Blog> Handle(
        GetBlogByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}
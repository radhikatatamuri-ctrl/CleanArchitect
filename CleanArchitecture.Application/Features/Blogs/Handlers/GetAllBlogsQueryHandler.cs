using CleanArchitecture.Application.Features.Blogs.Queries;
using CleanArchitecture.Domain.Enitites;
using CleanArchitecture.Domain.Interface;
using MediatR;

public class GetAllBlogsQueryHandler
    : IRequestHandler<GetAllBlogsQuery, List<Blog>>
{
    private readonly IBlogRepository _repository;

    public GetAllBlogsQueryHandler(
        IBlogRepository repository)
    {
        _repository = repository;
    }

    /*   public async Task<List<Blog>> Handle(
           GetAllBlogsQuery request,
           CancellationToken cancellationToken)
       {
           return await _repository.GetAllAsync();
       }*/
    public async Task<List<Blog>> Handle(
       GetAllBlogsQuery request,
       CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync(
            request.PageNumber,
            request.PageSize);
    }
}
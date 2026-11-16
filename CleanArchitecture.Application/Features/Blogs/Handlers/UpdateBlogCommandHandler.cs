using CleanArchitecture.Application.Features.Blogs.Commands;
using CleanArchitecture.Domain.Enitites;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Domain.ValueObjects;
using MediatR;

namespace CleanArchitecture.Application.Features.Blogs.Handlers
{
    public class UpdateBlogCommandHandler
        : IRequestHandler<UpdateBlogCommand, int>
    {
        private readonly IBlogRepository _repository;

        public UpdateBlogCommandHandler(
            IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(
            UpdateBlogCommand request,
            CancellationToken cancellationToken)
        {
                var blog = new Blog(
        new BlogName(request.Name),
        request.Description,
        request.Author,
        request.ImageUrl);
            return await _repository.UpdateAsync(request.blogId, blog);
        }
    }
}
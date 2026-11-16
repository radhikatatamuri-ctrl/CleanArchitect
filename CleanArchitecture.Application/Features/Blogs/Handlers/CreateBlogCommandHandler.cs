using CleanArchitecture.Application.Features.Blogs.Commands;
using CleanArchitecture.Application.Features.Blogs.Events;
using CleanArchitecture.Domain.Enitites;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Domain.ValueObjects;
using MediatR;

namespace CleanArchitecture.Application.Features.Blogs.Handlers
{
    public class CreateBlogCommandHandler
        : IRequestHandler<CreateBlogCommand, Blog>
    {
        private readonly IBlogRepository _repository;
        private readonly IMediator _mediator;
        public CreateBlogCommandHandler(
        IBlogRepository repository,
        IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<Blog> Handle(
            CreateBlogCommand request,
            CancellationToken cancellationToken)
        {
            var blog = new Blog(
                 new BlogName(request.Name),
                 request.Description,
                 request.Author,
                 request.ImageUrl);
            // return await _repository.CreateAsync(blog);
            var result = await _repository.CreateAsync(blog);

            await _mediator.Publish(
                new BlogCreatedEvent(
                    result.Id,
                    result.Name.Value));

            return result;
        }
    }
}
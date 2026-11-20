using CleanArchitecture.Application.Features.Blogs.Commands;
using CleanArchitecture.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Features.Blogs.Handlers
{
    public class RemoveCommentCommandHandler
     : IRequestHandler<RemoveCommentCommand, bool>
    {
        private readonly IBlogRepository _blogRepository;

        public RemoveCommentCommandHandler(
            IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<bool> Handle(
            RemoveCommentCommand request,
            CancellationToken cancellationToken)
        {
            var blog = await _blogRepository.GetByIdAsync(request.BlogId);

            if (blog == null)
                return false;

            blog.RemoveComment(request.CommentId);

            await _blogRepository.UpdateAsync(blog.Id, blog);

            return true;
        }
    }
}

using CleanArchitecture.Application.Features.Blogs.Commands.UpdateComment;
using CleanArchitecture.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Features.Blogs.Handlers
{
    public class UpdateCommentCommandHandler
      : IRequestHandler<UpdateCommentCommand, bool>
    {
        private readonly IBlogRepository _blogRepository;

        public UpdateCommentCommandHandler(
            IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<bool> Handle(
            UpdateCommentCommand request,
            CancellationToken cancellationToken)
        {
            var blog = await _blogRepository.GetByIdAsync(request.blogId);

            if (blog == null)
                return false;

            blog.UpdateComment(
                request.commentId,
                request.content);

            await _blogRepository.SaveChangesAsync();

            return true;
        }
    }
}

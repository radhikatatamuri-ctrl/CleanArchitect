using CleanArchitecture.Application.Features.Blogs.Commands.AddComment;
using CleanArchitecture.Domain.Enitites;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Features.Blogs.Handlers.AddComment
{
    public class AddCommentCommandHandler
        : IRequestHandler<AddCommentCommand, bool>
    {
        private readonly IBlogRepository _blogRepository;

        public AddCommentCommandHandler(
            IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<bool> Handle(
            AddCommentCommand request,
            CancellationToken cancellationToken)
        {
            var blog = await _blogRepository.GetByIdAsync(request.BlogId);

            if (blog == null)
                return false;


            blog.AddComment(request.Content,request.Author);

            await _blogRepository.SaveChangesAsync();

            return true;
        }
    }
}

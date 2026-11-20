using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Features.Blogs.Commands
{
    public class RemoveCommentCommand : IRequest<bool>
    {
        public int BlogId { get; set; }
        public int CommentId { get; set; }

        public RemoveCommentCommand(int blogId, int commentId)
        {
            BlogId = blogId;
            CommentId = commentId;
        }
    }
}

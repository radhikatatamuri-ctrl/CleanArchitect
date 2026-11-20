using Amazon.Runtime.Internal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Features.Blogs.Commands.UpdateComment
{
    public class UpdateCommentCommand : IRequest<bool>
    {
        public int blogId { get; set; }
        public int commentId { get; set; }
        public string content { get; set; }

        public UpdateCommentCommand(int blogId,int commentId,string content)
        {
            this.blogId = blogId;
            this.commentId = commentId;
            this.content = content;
            
        }
    }
}

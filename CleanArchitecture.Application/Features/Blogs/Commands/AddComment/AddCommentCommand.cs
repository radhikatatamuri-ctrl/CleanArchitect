using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Features.Blogs.Commands.AddComment
{
    public class AddCommentCommand : IRequest<bool>
    {
        public int BlogId { get; set; }

        public string Content { get; set; }
        public string Author { get; set; }
         public AddCommentCommand(int blogId, string content,string author)
    {
        BlogId = blogId;
        Content = content;
            Author= author;
    }

    }   
}

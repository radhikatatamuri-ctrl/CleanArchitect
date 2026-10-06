using CleanArchitecture.Domain.Enitites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Features.Blogs.Commands
{
    public record UpdateBlogCommand(
        int blogId,
    string Name,
    string Description,
    string Author,
    string ImageUrl)
    : IRequest<int>;
}



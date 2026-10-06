using CleanArchitecture.Domain.Enitites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Features.Blogs.Queries
{
    public record GetAllBlogsQuery()
 : IRequest<List<Blog>>;
}

using CleanArchitecture.Domain.Enitites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Features.Blogs.Queries
{
    //   public record GetAllBlogsQuery() : IRequest<List<Blog>>;
    public record GetAllBlogsQuery(
       int PageNumber = 1,
       int PageSize = 10,
       string? SortBy = null,
    bool Descending = false)
       : IRequest<List<Blog>>;
}

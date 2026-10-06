using CleanArchitecture.Domain.Enitites;
using MediatR;

namespace CleanArchitecture.Application.Features.Blogs.Queries;

public record GetBlogByIdQuery(int Id)
    : IRequest<Blog>;
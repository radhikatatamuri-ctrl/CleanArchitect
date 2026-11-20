using CleanArchitecture.API.Requests;
using CleanArchitecture.Application.Features.Blogs.Commands;
using CleanArchitecture.Application.Features.Blogs.Commands.AddComment;
using CleanArchitecture.Application.Features.Blogs.Commands.UpdateComment;
using CleanArchitecture.Application.Features.Blogs.Queries;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Enitites;
using CleanArchitecture.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly IMediator _mediator;
        private readonly BlogDbContext _blogDbContext;
        public BlogController(IBlogService blogService, IMediator mediator, BlogDbContext blogDbContext)
        {
            _blogService = blogService;
            _mediator = mediator;
            _blogDbContext = blogDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(
                             new GetAllBlogsQuery());

            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(
                            new GetBlogByIdQuery(id));

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Blog blog)
        {
            var command = new CreateBlogCommand(
                blog.Id,
                blog.Name.Value,
                blog.Description,
                blog.Author,
                blog.ImageUrl);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Blog updatedBlog)
        {
            int existingBlog = await _blogService.UpdateAsync(id, updatedBlog);
            if (existingBlog == 0)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(
                new DeleteBlogCommand(id));

            if (result == 0)
            {
                return NotFound();
            }

            return Ok("Blog deleted successfully");
        }
        [HttpGet("auditlogs")]
        public async Task<IActionResult> GetAuditLogs()
        {
            var logs = await _blogDbContext.AuditLogs.ToListAsync();
            return Ok(logs);
        }
        [HttpPut("{blogId}/comments/{commentId}")]
        public async Task<IActionResult> UpdateComment(
            int blogId,
            int commentId,
            UpdateCommentRequest request)
        {
            var command =
                  new UpdateCommentCommand(
                      blogId,
                      commentId,
                      request.content);
            var result= await _mediator.Send(command);
              return result ? Ok() : NotFound();

        }

        [HttpPost("{blogId}/comments")]
        public async Task<IActionResult> AddComment(
    int blogId,
    AddCommentRequest request)
        {
            var command = new AddCommentCommand(blogId,
       request.Content,request.Author);

       //     var result = await _mediator.Send(command);
            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{blogId}/comments/{commentId}")]
        public async Task<IActionResult> RemoveComment(
    int blogId,
    int commentId)
        {
            var command = new RemoveCommentCommand(
                blogId,
                commentId);

            var result = await _mediator.Send(command);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}

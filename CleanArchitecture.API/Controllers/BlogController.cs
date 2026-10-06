using CleanArchitecture.Application.Features.Blogs.Commands;
using CleanArchitecture.Application.Features.Blogs.Queries;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Enitites;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly IMediator _mediator;

        public BlogController(IBlogService blogService, IMediator mediator)
        {
            _blogService = blogService;
            _mediator = mediator;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(
                             new GetAllBlogsQuery());

            return Ok(result);
        }

        /*   [HttpGet]
           public async Task<IActionResult> GetAll()
           {
               var blogs = await _blogService.GetAllAsync();
               return Ok(blogs);
           }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }
        */
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(
                            new GetBlogByIdQuery(id));

            if (result == null)
                return NotFound();

            return Ok(result);
        }
        /*   [HttpPost]
           public async Task<IActionResult> Create(Blog blog)
           {
               var createdBlog = await _blogService.CreateAsync(blog);
               return CreatedAtAction(nameof(GetById), new { id = createdBlog.Id }, createdBlog);
           }*/
        [HttpPost]
        public async Task<IActionResult> Create(Blog blog)
        {
            var command = new CreateBlogCommand(
                blog.Id,
                blog.Name,
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

        /*   [HttpDelete("{id}")]
           public async Task<IActionResult> Delete(int id)
           {
               int blog = await _blogService.DeleteAsync(id);
               if (blog == 0)
               {
                   return BadRequest();
               }
               return NoContent();
           }*/
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
    }
}

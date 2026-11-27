using CleanArchitecture.Domain.Enitites;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Domain.ValueObjects;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _blogDbContext;

        public BlogRepository(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }
        public async Task<Blog> CreateAsync(Blog blog)
        {
            await _blogDbContext.Blogs.AddAsync(blog);
            await _blogDbContext.SaveChangesAsync();
            return blog;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var blog = await _blogDbContext.Blogs
    .FirstOrDefaultAsync(x => x.Id == id);

            if (blog == null)
                return 0;

            _blogDbContext.Blogs.Remove(blog);

            return await _blogDbContext.SaveChangesAsync();
        }

        /*   public async Task<List<Blog>> GetAllAsync()
           {
               return await _blogDbContext.Blogs.Include(b => b.Comments).ToListAsync();
           }*/
        public async Task<List<Blog>> GetAllAsync(
       int pageNumber,
       int pageSize,string sortBy,bool descending)
        {
            /* return await _blogDbContext.Blogs.Include(b => b.Comments)
                   .OrderBy(b => b.Id)
                 .Skip((pageNumber - 1) * pageSize)
                 .Take(pageSize)
                 .ToListAsync();*/
            var query = _blogDbContext.Blogs
     .Include(b => b.Comments)
     .AsQueryable();

            if (!string.IsNullOrEmpty(sortBy))
            {
                query = sortBy.ToLower() switch
                {
                    "name" => descending
                        ? query.OrderByDescending(b => b.Name.Value)
                        : query.OrderBy(b => b.Name.Value),

                    "author" => descending
                        ? query.OrderByDescending(b => b.Author)
                        : query.OrderBy(b => b.Author),

                    _ => query.OrderByDescending(b => b.Id)
                };
            }
            else
            {
                query = query.OrderByDescending(b => b.Id);
            }

            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await _blogDbContext.Blogs
                        .Include(x => x.Comments)
               .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> UpdateAsync(int id, Blog blog)
        {
           
            var existingBlog = await _blogDbContext.Blogs
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingBlog == null)
                return 0;

            existingBlog.Update(
                new BlogName(blog.Name.Value),
                blog.Description,
                blog.Author,
                blog.ImageUrl);

            return await _blogDbContext.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _blogDbContext.SaveChangesAsync();
        }
    }
    }


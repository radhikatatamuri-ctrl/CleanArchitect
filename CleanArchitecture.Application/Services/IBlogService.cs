using CleanArchitecture.Domain.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public interface IBlogService
    {
        //  Task<List<Blog>> GetAllAsync();
        Task<List<Blog>> GetAllAsync(
      int pageNumber,
      int pageSize);
        Task<Blog> GetByIdAsync(int id);
        Task<Blog> CreateAsync(Blog blog);
        Task<int> UpdateAsync(int id, Blog blog);
        Task<int> DeleteAsync(int id);
    }
}

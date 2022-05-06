using APICore.Common.DTO.Request;
using APICore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICore.Services
{
    public interface ICategoryService
    {
        Task<Category> GetCategoryAsync(int categID);
        Task<Category> PutCategoryAsync(CategoryRequest categ);
        Task<IQueryable<Category>> GetAllCategoriesAsync();
        Task<Category> UpdateCategoryAsync(CategoryRequest category, int iD);
        Task DeleteCategoryAsync(int catID);
    }
}

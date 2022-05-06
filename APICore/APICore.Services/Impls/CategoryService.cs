using APICore.Common.DTO.Request;
using APICore.Data.Entities;
using APICore.Data.UoW;
using APICore.Services.Exceptions.NotFound;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICore.Services.Impls
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _uow;
        private readonly IStringLocalizer<IAccountService> _localizer;
        public CategoryService(IUnitOfWork uow, IStringLocalizer<IAccountService> localizer)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
        }

        public async Task<IQueryable<Category>> GetAllCategoriesAsync()
        {
            var categories = _uow.CategoryRepository
                                    .GetAll();
            if (categories == null)
            {
                throw new CategoryNotFoundException(_localizer);
            }

            return await Task.FromResult(categories);
        }

        public async Task<Category> GetCategoryAsync(int categID)
        {
            var category = await _uow.CategoryRepository
                                    .FirstOrDefaultAsync(c => c.Id == categID);
            if (category == null)
            {
                throw new CategoryNotFoundException(_localizer);
            }

            return category;
        }

        public async Task<Category> PutCategoryAsync(CategoryRequest categRequest)
        {
            if (categRequest == null)
            {
                throw new ArgumentNullException(nameof(categRequest));
            }

            var result = await _uow.CategoryRepository
                                   .FirstOrDefaultAsync(c => c.Name == categRequest.Name);

            if (result != null)
            {
                result.Description = categRequest.Description;
                _uow.CategoryRepository.Update(result);
            }
            else
            {
                result = new Category { Name = categRequest.Name, Description = categRequest.Description };
                await _uow.CategoryRepository.AddAsync(result);
            }

            await _uow.CommitAsync();

            return result;
        }

        public async Task<Category> UpdateCategoryAsync(CategoryRequest category, int iD)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            var result = await _uow.CategoryRepository
                                   .FirstOrDefaultAsync(c => c.Id == iD);

            if (result != null)
            {
                result.Name = category.Name;
                result.Description = category.Description;
                await _uow.CategoryRepository.UpdateAsync(result, iD);
                await _uow.CommitAsync();
                return result;
            }
            else
            {
                throw new AuthorNotFoundException(_localizer);
            }
        }
    }
}

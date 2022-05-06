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
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _uow;
        private readonly IStringLocalizer<IAccountService> _localizer;
        public AuthorService(IUnitOfWork uow, IStringLocalizer<IAccountService> localizer)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
        }
        public async Task DeleteAuthorAsync(int authorID)
        {
            var author = await _uow.AuthorRepository.FindAsync(c => c.Id == authorID) ;
            
            if (author == null)
            {
                throw new AuthorNotFoundException(_localizer);
            }

            _uow.AuthorRepository.Delete(author);
            await _uow.CommitAsync();
        }

        public async Task<IQueryable<Author>> GetAllAuthorsAsync()
        {
            var authors = _uow.AuthorRepository
                        .GetAll();
            if (authors == null)
            {
                throw new AuthorNotFoundException(_localizer);
            }

            return await Task.FromResult(authors);
        }

        public async Task<Author> GetAuthorAsync(int authorID)
        {
            var author = await _uow.AuthorRepository
                         .FirstOrDefaultAsync(c => c.Id == authorID);
            if (author == null)
            {
                throw new CategoryNotFoundException(_localizer);
            }

            return author;
        }

        public async Task<Author> PutAuthorAsync(AuthorRequest author)
        {
            if (author == null)
            {
                throw new ArgumentNullException(nameof(author));
            }

            var result = await _uow.AuthorRepository
                                   .FirstOrDefaultAsync(c => c.FistName == author.FirstName && c.LastName == author.LastName);

            if (result != null)
            {
                result.Website = author.WebsiteName;
                _uow.AuthorRepository.Update(result);
            }
            else
            {
                result = new Author { FistName = author.FirstName, LastName = author.LastName, Website = author.WebsiteName };
                await _uow.AuthorRepository.AddAsync(result);
            }

            await _uow.CommitAsync();

            return result;
        }

        public async Task<Author> UpdateAuthorAsync(int ID, AuthorRequest author)
        {
            if (author == null)
            {
                throw new ArgumentNullException(nameof(author));
            }

            var result = await _uow.AuthorRepository
                                   .FirstOrDefaultAsync(c => c.Id == ID);

            if (result != null)
            {
                result.FistName = author.FirstName;
                result.LastName = author.LastName;
                result.Website = author.WebsiteName;
                await _uow.AuthorRepository.UpdateAsync(result, ID);
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

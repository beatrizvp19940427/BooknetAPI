using APICore.Common.DTO.Request;
using APICore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICore.Services
{
    public interface IAuthorService
    {

        Task<Author> GetAuthorAsync(int authorID);
        Task<Author> PutAuthorAsync(AuthorRequest author);
        Task<IQueryable<Author>> GetAllAuthorsAsync();
        Task<Author> UpdateAuthorAsync(int ID, AuthorRequest author);
        Task DeleteAuthorAsync(int authorID);

    }
}


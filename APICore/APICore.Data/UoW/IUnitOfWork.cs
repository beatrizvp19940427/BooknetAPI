using APICore.Data.Entities;
using APICore.Data.Repository;
using System;
using System.Threading.Tasks;

namespace APICore.Data.UoW
{
    public interface IUnitOfWork
    {
        IGenericRepository<User> UserRepository { get; set; }
        IGenericRepository<UserToken> UserTokenRepository { get; set; }
        IGenericRepository<Setting> SettingRepository { get; set; }
        IGenericRepository<Log> LogRepository { get; set; }
        IGenericRepository<Book> BookRepository { get; set; }
        IGenericRepository<Author> AuthorRepository { get; set; }
        IGenericRepository<Category> CategoryRepository { get; set; }
        Task<int> CommitAsync();
    }
}
using APICore.Data.Entities;
using APICore.Data.Repository;
using System;
using System.Threading.Tasks;

namespace APICore.Data.UoW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CoreDbContext _context;

        public UnitOfWork(CoreDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            UserRepository ??= new GenericRepository<User>(_context);
            UserTokenRepository ??= new GenericRepository<UserToken>(_context);
            SettingRepository ??= new GenericRepository<Setting>(_context);
            LogRepository ??= new GenericRepository<Log>(_context);
            BookRepository ??= new GenericRepository<Book>(_context);
            AuthorRepository ??= new GenericRepository<Author>(_context);
            CategoryRepository ??= new GenericRepository<Category>(_context);
        }

        public IGenericRepository<User> UserRepository { get; set; }
        public IGenericRepository<UserToken> UserTokenRepository { get; set; }
        public IGenericRepository<Setting> SettingRepository { get; set; }
        public IGenericRepository<Log> LogRepository { get; set; }
        public IGenericRepository<Book> BookRepository { get; set; }
        public IGenericRepository<Author> AuthorRepository { get; set; }
        public IGenericRepository<Category> CategoryRepository { get; set; }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
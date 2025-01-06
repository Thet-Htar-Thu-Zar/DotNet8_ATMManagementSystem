using Microsoft.Extensions.Options;
using Model;
using Model.ApplicationConfig;
using Model.Entities;
using Repo.Repositories.IRepositories;
using Repo.Repositories.Repositories;

namespace Repo.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _context;

        public UnitOfWork(DataContext context, IOptions<Appsetting> appsettings)
        {
            _context = context;
            Appsetting = appsettings.Value;
            User = new UserRepository(context);
            StoreFile = new FileRepository(context);
            Transactions = new Transactions(context);
        }
        public IUserRepository User { get; set; }
        public IFileRepository StoreFile { get; set; }
        public Appsetting Appsetting { get; set; }
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

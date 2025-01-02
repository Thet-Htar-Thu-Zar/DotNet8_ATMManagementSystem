using Model;
using Model.Entities;
using Repo.Repositories.IRepositories;

namespace Repo.Repositories.Repositories
{
    internal class FileRepository : GenericRepository<Files>, IFileRepository
    {
        public FileRepository(DataContext context) : base(context)
        {
        }
    }
}

using BAL.IServices;
using Microsoft.AspNetCore.Http;
using Repo.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class FileServices : IFileServices
    {
        public Task<string> FileUpload(IFormFile File)
        {
            throw new NotImplementedException();
        }
    }
}

using BAL.IServices;
using BAL.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Model;
using Model.ApplicationConfig;
using Repo.UnitOfWork;

namespace BAL.Shared
{
    public class ServiceManager
    {
        public static void SetServicesInfo(IServiceCollection services, Appsetting appSettings)
        {
            services.AddDbContextPool<DataContext>(options =>
            {
                options.UseSqlServer(appSettings.ConnectionStrings);
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IFileServices, FileServices>();

        }
    }
}

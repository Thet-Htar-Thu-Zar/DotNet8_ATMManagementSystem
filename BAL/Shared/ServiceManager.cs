using Microsoft.Extensions.Options;
using Model.ApplicationConfig;

namespace BAL.Shared
{
    public class ServiceManager
    {
        public static void SetServicesInfo(IServiceCollection services, Appsetting appSettings)
        {
            services.AddDbContextPool<DataContext>(Options =>
            {
                Options.UseSqlServer(appSettings.ConnectionStrings);
            });
            
        }
    }
}

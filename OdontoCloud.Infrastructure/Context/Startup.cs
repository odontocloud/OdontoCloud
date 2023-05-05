using Microsoft.Extensions.DependencyInjection;

namespace OdontoCloud.Infrastructure.Context
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
            => services.AddDbContext<OdontoCloudDBContext>();

        public void Configure() { }
    }
    
}

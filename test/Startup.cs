using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BridgeLibrary.Entities;
using BridgeLibrary.Entities.Repositories;
namespace BridgeLibrary
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserRepository<User>, UserRepository>();
            services.AddScoped<IBillfoldRepository<BillFold>, BillfoldRepository>();
            services.AddScoped<IIssuerRepository<Issuer>, IssuerRepository>();
        }
    }
}
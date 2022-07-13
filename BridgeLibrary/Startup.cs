using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BridgeLibrary.Entities;
using BridgeLibrary.Entities.Repositories;
namespace BridgeLibrary
{
    ///<summary> The class <c>Startup</c> is the entry point of the application.
    ///It contains the necessary configurations ,services and connection strings to external ressources.
    ///</summary>
    public class Startup
    {
        ///<summary> The constructor </summary>
        ///<param name="configuration"> A parameter of type IConfiguration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        ///<value> Represents the application configuration properties.</value>
        public IConfiguration Configuration { get; }

        /// <summary>This method gets called by the runtime. Use this method to add services to the container.</summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserRepository<User>, UserRepository>();
            services.AddScoped<IBillfoldRepository<BillFold>, BillfoldRepository>();
            services.AddScoped<IIssuerRepository<Issuer>, IssuerRepository>();

        }
    }
}
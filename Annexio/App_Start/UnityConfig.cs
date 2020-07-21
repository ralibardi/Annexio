using System.Web.Mvc;
using Annexio.Builders;
using Annexio.Clients;
using Unity;
using Unity.Mvc5;

namespace Annexio
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            container.RegisterType<ICountriesHttpClient, CountriesHttpClient>();
            container.RegisterType<IDetailsHttpClient, DetailsHttpClient>();
            container.RegisterType<IRestCountriesUriBuilder, RestCountriesUriBuilder>();
        }
    }
}
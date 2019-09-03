using System.Web.Http;
using Unity;
using Unity.WebApi;
using UsersWebapi.Data.Interfaces;
using UsersWebapi.Data.Repositories;

namespace UsersWebapi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IUserRepository, UserRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
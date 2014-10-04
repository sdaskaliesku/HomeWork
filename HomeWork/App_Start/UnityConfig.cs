using HomeWork.Repository;
using HomeWork.Service;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace HomeWork
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<IGenresRepository, GenresRepository>();
            container.RegisterType<IGenresService, GenresService>();
            container.RegisterType<IMoviesRepository, MoviesRepository>();
            container.RegisterType<IMoviesService, MoviesService>();
            container.RegisterType<IActorsRepository, ActorsRepository>();
            container.RegisterType<IActorsService, ActorsService>();
            // e.g. container.RegisterType<ITestService, TestService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
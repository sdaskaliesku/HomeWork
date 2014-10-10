using System.Web.Mvc;
using HomeWork.Repository;
using HomeWork.Service;
using Microsoft.Practices.Unity;
using Unity.Mvc4;

namespace HomeWork
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
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
            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {

        }
    }
}

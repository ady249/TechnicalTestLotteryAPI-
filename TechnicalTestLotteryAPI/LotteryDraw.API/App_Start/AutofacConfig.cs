using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;

namespace LotteryDraw.API
{
    public static class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterAssemblyTypes(Assembly.Load("LotteryDraw.Models")).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(Assembly.Load("LotteryDraw.Repository.Memory")).AsImplementedInterfaces();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(builder.Build());
        }
    }
}
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using LotteryDraw.Models.Interfaces.Storage;
using LotteryDraw.Repository.Memory.Storage;

namespace LotteryDraw.API
{
    public static class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterAssemblyTypes(Assembly.Load("LotteryDraw.BusinessLogic")).AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.Load("LotteryDraw.Models")).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(Assembly.Load("LotteryDraw.Repository.Memory")).AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.Load("LotteryDraw.Tracer.DebugTracer")).AsImplementedInterfaces();

            builder.RegisterType<PersistantStorage>().As<IPersistantStorage>().SingleInstance();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(builder.Build());
        }
    }
}
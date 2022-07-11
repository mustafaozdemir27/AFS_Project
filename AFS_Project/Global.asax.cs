using AFS_Project.Repositories.Abstract;
using AFS_Project.Repositories.Concrete;
using Autofac;
using Autofac.Integration.Mvc;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.ADONET;
using DataAccess.Services.FunTranslationService.Common;
using DataAccess.Services.FunTranslationService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AFS_Project
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<SearchLogManager>().As<ISearchLogService>();
            builder.RegisterType<SearchLogDal>().As<ISearchLogDal>();

            builder.RegisterType<FunTranslationService>().As<IFunTranslationService>();
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<UserDal>().As<IUserDal>();
            builder.RegisterType<SessionRepository>().As<ISessionRepository>();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
    }
}

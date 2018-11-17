using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppName.Web.App_Start
{
    public class AutofacConfig
    {
        public static AutofacDependencyResolver Resolver { get; set; }

        public static IContainer Container { get; set; }

        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(typeof(AutofacConfig).Assembly);

            Container = builder.Build();
            Resolver = new AutofacDependencyResolver(Container);
            DependencyResolver.SetResolver(Resolver);
            return Container;
        }
    }
}
using AppName.Logic.Interfaces;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppName.Web.App_Start.AutofacModules
{
    public class LogicModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ILogic).Assembly)
                    .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(ILogic).Assembly)
                    .AsSelf();

        }
    }
}
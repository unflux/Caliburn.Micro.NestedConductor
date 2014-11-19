namespace Caliburn.Micro.Nested.Conductors
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using Autofac;
    using Caliburn.Micro;
    using Caliburn.Micro.Nested.Conductors.Framework;
    using Caliburn.Micro.Nested.Conductors.ViewModels;

    public class AppBootstrapper : BootstrapperBase
    {
        private IContainer container;

        public AppBootstrapper()
        {
            this.Initialize();
        }

        protected override void Configure()
        {
            var builder = new ContainerBuilder();

            // Caliburn.Micro framework object registration
            builder.RegisterType<WindowManager>()
                   .AsImplementedInterfaces()
                   .AsSelf()
                   .SingleInstance();
            builder.RegisterType<EventAggregator>()
                   .AsImplementedInterfaces()
                   .AsSelf()
                   .SingleInstance();

            // ViewModel registration
            builder.RegisterType<MainWindowViewModel>()
                   .AsSelf()
                   .SingleInstance();
            builder.RegisterType<ContainerViewModel>()
                   .As<IWorkspace>()
                   .SingleInstance();
            builder.RegisterType<AnyViewModel>()
                   .As<IWorkspace>()
                   .InstancePerDependency();

            //builder.RegisterType<NestedContainerProvider>()
            //       .As<INestedContainerProvider>()
            //       .SingleInstance();

            builder.Register(ctx => new NestedConductorProvider())
                   .OnActivated(ctx => ctx.Instance.Workspaces = ctx.Context.Resolve<IEnumerable<IWorkspace>>())
                   .As<INestedConductorProvider>()
                   .InstancePerLifetimeScope();

            this.container = builder.Build();
        }

        protected override object GetInstance(Type service, string key)
        {
            object instance;
            if (string.IsNullOrWhiteSpace(key))
            {
                if (this.container.TryResolve(service, out instance))
                {
                    return instance;
                }
            }
            else
            {
                if (this.container.TryResolveNamed(key, service, out instance))
                {
                    return instance;
                }
            }
            throw new Exception(string.Format("Could not locate any instances of contract {0}.", key ?? service.Name));
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return this.container.Resolve(typeof (IEnumerable<>).MakeGenericType(service)) as IEnumerable<object>;
        }

        protected override void BuildUp(object instance)
        {
            this.container.InjectProperties(instance);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            this.DisplayRootViewFor<MainWindowViewModel>();
        }
    }
}
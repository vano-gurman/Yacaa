using System.Windows;
using System.Windows.Threading;
using FluentValidation;
using Stylet;
using StyletIoC;
using Yacaa.Interfaces.Factories;
using Yacaa.Interfaces.ViewModels;
using Yacaa.Logging;
using Yacaa.Validation;
using Yacaa.ViewModels;
using ILogger = Yacaa.Interfaces.Logging.ILogger;

namespace Yacaa
{
    public class Bootstrapper : Bootstrapper<LoginViewModel>
    {
        protected override void OnStart()
        {
            // This is called just after the application is started, but before the IoC container is set up.
            // Set up things like logging, etc
        }
 
        protected override void ConfigureIoC(IStyletIoCBuilder builder)
        {
            // Bind your own types. Concrete types are automatically self-bound.
            // builder.Bind<IMyInterface>().To<MyType>();
            builder.Bind(typeof(IModelValidator<>)).To(typeof(FluentModelValidator<>));
            builder.Bind(typeof(IValidator<>)).ToAllImplementations();
            builder.Bind<ILogger>().To<Logger>().InSingletonScope().AsWeakBinding();
            builder.Bind<IContentViewModelFactory>().ToAbstractFactory();
        }
 
        protected override void Configure()
        {
            // This is called after Stylet has created the IoC container, so this.Container exists, but before the
            // Root ViewModel is launched.
            // Configure your services, etc, in here
            var viewManager = this.Container.Get<ViewManager>();
            var some = this.Container.GetAll(typeof(IContentViewModel));
        }
 
        protected override void OnLaunch()
        {
            // This is called just after the root ViewModel has been launched
            // Something like a version check that displays a dialog might be launched from here
        }
 
        protected override void OnExit(ExitEventArgs e)
        {
            // Called on Application.Exit
        }
 
        protected override void OnUnhandledException(DispatcherUnhandledExceptionEventArgs e)
        {
            Container.Get<ILogger>().Fatal(e.Exception);
        }
    }
}
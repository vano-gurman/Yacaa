using System.Reflection;
using System.Windows;
using System.Windows.Threading;
using FluentValidation;
using NLog;
using Stylet;
using StyletIoC;
using Yacaa.Interfaces.Factories;
using Yacaa.Interfaces.ViewModels;
using Yacaa.Services.DataAccess;
using Yacaa.Services.Settings;
using Yacaa.Services.Settings.Configuration;
using Yacaa.Services.Settings.Enum;
using Yacaa.Validation;
using Yacaa.ViewModels;

namespace Yacaa
{
    public class Bootstrapper : Bootstrapper<LoginViewModel>
    {
        protected override void OnStart()
        {
            // This is called just after the application is started, but before the IoC container is set up.
            // Set up things like logging, etc
#if DEBUG
            Stylet.Logging.LogManager.Enabled = true;
#endif
            
        }
 
        protected override void ConfigureIoC(IStyletIoCBuilder builder)
        {
            // Bind your own types. Concrete types are automatically self-bound.
            // builder.Bind<IMyInterface>().To<MyType>();
            builder.Bind(typeof(IModelValidator<>)).To(typeof(FluentModelValidator<>));
            builder.Bind(typeof(IValidator<>)).ToAllImplementations();
            builder.Bind<IContentViewModelFactory>().ToAbstractFactory();
            builder.Bind<SettingsConfiguration>().ToSelf().InSingletonScope();
            builder.Bind<SettingsService>().ToSelf().InSingletonScope(); }
 
        protected override void Configure()
        {
            // This is called after Stylet has created the IoC container, so this.Container exists, but before the
            // Root ViewModel is launched.
            // Configure your services, etc, in here
            Container.Get<SettingsService>().SettingsConfiguration.StorageSpace = StorageSpace.UserRoaming;
            Container.Get<SettingsService>().SettingsConfiguration.SubDirectoryPath = Strings.Common.ApplicationName;
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
            //Container.Get<ILogger>().Fatal(e.Exception);
            var logger = LogManager.GetCurrentClassLogger();
            logger.Error(e.Exception, "An unhandled exception occurred");
            if (e.Exception is ReflectionTypeLoadException typeLoadException)
            {
                logger.Error("Loader exceptions:");
                foreach (var ex in typeLoadException.LoaderExceptions)
                {
                    logger.Error(ex);
                }
            }
        }
    }
}
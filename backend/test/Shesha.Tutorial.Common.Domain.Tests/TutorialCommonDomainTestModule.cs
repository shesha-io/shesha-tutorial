using Abp;
using Abp.AspNetCore.Configuration;
using Abp.Castle.Logging.Log4Net;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.Modules;
using Abp.Net.Mail;
using Abp.TestBase;
using Abp.Zero.Configuration;
using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Moq;
using NSubstitute;
using Shesha.Tutorial.Domain;
using Shesha.Tutorial.Tests.DependencyInjection;
using Shesha;
using Shesha.FluentMigrator;
using Shesha.NHibernate;
using Shesha.Services;
using System;
using System.Reflection;

namespace Shesha.Tutorial.Common.Tests
{
    [DependsOn(
        typeof(tutorialModule),
        typeof(AbpKernelModule),
        typeof(AbpTestBaseModule),
        typeof(SheshaApplicationModule),
        typeof(SheshaNHibernateModule),
        typeof(SheshaFrameworkModule)
        )]
    public class tutorialCommonDomainTestModule : AbpModule
    {
        private string ConnectionString;

        public tutorialCommonDomainTestModule(SheshaNHibernateModule nhModule)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.Test.json").Build();
            ConnectionString = config.GetConnectionString("TestDB");

            nhModule.ConnectionString = ConnectionString;
            nhModule.SkipDbSeed = false; // Set to false to apply DB Migration files on start up
        }

        public override void PreInitialize()
        {
            Configuration.UnitOfWork.Timeout = TimeSpan.FromMinutes(30);
            Configuration.UnitOfWork.IsTransactional = false;

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;

            // mock IWebHostEnvironment
            IocManager.IocContainer.Register(Component.For<IWebHostEnvironment>().ImplementedBy<TestWebHostEnvironment>().LifestyleSingleton());

            IocManager.IocContainer.Register(
                Component.For<IAbpAspNetCoreConfiguration>()
                    .ImplementedBy<AbpAspNetCoreConfiguration>()
                    .LifestyleSingleton()
            );

            var appLifetimeMoq = new Mock<IHostApplicationLifetime>();
            IocManager.IocContainer.Register(
                Component.For<IHostApplicationLifetime>()
                    .Instance(appLifetimeMoq.Object)
                    .LifestyleSingleton()
            );

            var configuration = new Mock<IConfiguration>();
            configuration.Setup(c => c.GetSection(It.IsAny<String>())).Returns(new Mock<IConfigurationSection>().Object);
            IocManager.IocContainer.Register(
                Component.For<IConfiguration>()
                    .Instance(configuration.Object)
                    .LifestyleSingleton()
            );

            IocManager.IocContainer.Register(
                Component.For<IBackgroundJobClient>()
                    .UsingFactoryMethod(() =>
                    {
                        var storage = new SqlServerStorage(ConnectionString);
                        JobStorage.Current = storage;
                        return new BackgroundJobClient(storage);
                    })
                    .LifestyleSingleton()
            );

            // Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            RegisterFakeService<SheshaDbMigrator>();

            Configuration.ReplaceService<IDynamicRepository, DynamicRepository>(DependencyLifeStyle.Transient);

            // replace email sender
            Configuration.ReplaceService<IEmailSender, NullEmailSender>(DependencyLifeStyle.Transient);

            Configuration.ReplaceService<ICurrentUnitOfWorkProvider, AsyncLocalCurrentUnitOfWorkProvider>(DependencyLifeStyle.Singleton);

            if (!IocManager.IsRegistered<ApplicationPartManager>())
                IocManager.IocContainer.Register(Component.For<ApplicationPartManager>().ImplementedBy<ApplicationPartManager>());
        }

        public override void Initialize()
        {
            var thisAssembly = Assembly.GetExecutingAssembly();
            IocManager.RegisterAssemblyByConvention(thisAssembly);

            IocManager.IocContainer.AddFacility<LoggingFacility>(f => f.UseAbpLog4Net().WithConfig("log4net.config"));

            StaticContext.SetIocManager(IocManager);

            ServiceCollectionRegistrar.Register(IocManager);
        }

        private void RegisterFakeService<TService>() where TService : class
        {
            IocManager.IocContainer.Register(
                Component.For<TService>()
                    .UsingFactoryMethod(() => Substitute.For<TService>())
                    .LifestyleSingleton()
            );
        }
    }
}

using System.Reflection;
using Abp.AspNetCore.Configuration;
using Abp.AutoMapper;
using Abp.Modules;
using Intent.RoslynWeaver.Attributes;
using Shesha.Modules;
using Shesha.Settings.Ioc;
using Shesha.Tutorial.Domain.Configurations.Membership;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Boxfusion.Modules.Domain.Module", Version = "1.0")]

namespace Shesha.Tutorial.Domain
{
    [IntentManaged(Mode.Ignore)]
    /// <summary>
    /// tutorialCommon Module
    /// </summary>
    [DependsOn(
        typeof(SheshaCoreModule),
        typeof(SheshaApplicationModule)
    )]
    public class tutorialModule : SheshaModule
    {
        public override SheshaModuleInfo ModuleInfo => new SheshaModuleInfo("Shesha.Tutorial")
        {
            FriendlyName = "Tutorial",
            Publisher = "Boxfusion",
        };
        /// inheritedDoc
        public override void Initialize()
        {
            var thisAssembly = Assembly.GetExecutingAssembly();
            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }

        /// inheritedDoc
        public override void PreInitialize()
        {
            base.PreInitialize();

            IocManager.RegisterSettingAccessor<IMembershipSettings>(s =>
            {
                s.DebitDay.WithDefaultValue(1);
                s.MembershipPayments.WithDefaultValue(new MembershipPaymentSettings
                {
                    DebitDay = 1,
                    InitialReminder = 3,
                    DueDateReminder = true,
                    FirstOverdueReminder = 1,
                    SubsequentOverdueReminder = 7,
                    FinalNotice = 30
                });
            });
        }

        /// inheritedDoc
        public override void PostInitialize()
        {
            Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(
                typeof(tutorialModule).Assembly,
                moduleName: "tutorialCommon",
                useConventionalHttpVerbs: true);
        }
    }
}

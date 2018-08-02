using Autofac;
using Lykke.Service.EthereumSignService.Core.Services;
using Lykke.Service.EthereumSignService.Services;

namespace Lykke.Service.EthereumSignService.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // TODO: Do not register entire settings in container, pass necessary settings to services which requires them
            // ex:
            //  builder.RegisterType<QuotesPublisher>()
            //      .As<IQuotesPublisher>()
            //      .WithParameter(TypedParameter.From(_settings.CurrentValue.QuotesPublication))
            
            builder.RegisterType<HealthService>()
                .As<IHealthService>()
                .SingleInstance();

            builder.RegisterType<StartupManager>()
                .As<IStartupManager>();

            builder.RegisterType<ShutdownManager>()
                .As<IShutdownManager>();

            // TODO: Add your dependencies here
            builder.RegisterType<Services.SignService>()
                .As<ISignService>().SingleInstance();

            builder.RegisterType<ValidationService>()
                .As<IValidationService>().SingleInstance();

            builder.RegisterType<WalletCreationService>()
                .As<IWalletCreationService>().SingleInstance();
        }
    }
}

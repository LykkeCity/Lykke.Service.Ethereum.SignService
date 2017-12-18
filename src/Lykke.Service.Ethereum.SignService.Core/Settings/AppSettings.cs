using Lykke.Service.Ethereum.SignService.Core.Settings.ServiceSettings;
using Lykke.Service.Ethereum.SignService.Core.Settings.SlackNotifications;

namespace Lykke.Service.Ethereum.SignService.Core.Settings
{
    public class AppSettings
    {
        public EthereumClassicSignServiceSettings EthereumSignServiceService { get; set; }
        public SlackNotificationsSettings SlackNotifications { get; set; }
    }
}

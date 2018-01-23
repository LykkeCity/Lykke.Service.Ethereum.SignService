using Lykke.Service.EthereumSignService.Core.Settings.ServiceSettings;
using Lykke.Service.EthereumSignService.Core.Settings.SlackNotifications;

namespace Lykke.Service.EthereumSignService.Core.Settings
{
    public class AppSettings
    {
        public EthereumSignServiceSettings EthereumSignServiceService { get; set; }
        public SlackNotificationsSettings SlackNotifications { get; set; }
    }
}

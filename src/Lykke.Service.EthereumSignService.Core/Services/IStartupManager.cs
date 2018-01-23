using System.Threading.Tasks;

namespace Lykke.Service.EthereumSignService.Core.Services
{
    public interface IStartupManager
    {
        Task StartAsync();
    }
}
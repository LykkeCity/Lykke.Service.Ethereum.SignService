using System.Threading.Tasks;

namespace Lykke.Service.EthereumSignService.Core.Services
{
    public interface IShutdownManager
    {
        Task StopAsync();
    }
}
using System.Threading.Tasks;

namespace Lykke.Service.Ethereum.SignService.Core.Services
{
    public interface IShutdownManager
    {
        Task StopAsync();
    }
}
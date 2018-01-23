using System.Threading.Tasks;
using Lykke.Service.EthereumSignService.Core.Domain;

namespace Lykke.Service.EthereumSignService.Core.Services
{
    public interface IWalletCreationService
    {
        Task<KeyModel> CreateKeyModelAsync();
    }
}

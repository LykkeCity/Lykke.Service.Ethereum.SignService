using System.Threading.Tasks;
using Lykke.Service.Ethereum.SignService.Core.Domain;

namespace Lykke.Service.Ethereum.SignService.Core.Services
{
    public interface IWalletCreationService
    {
        Task<KeyModel> CreateKeyModelAsync();
    }
}

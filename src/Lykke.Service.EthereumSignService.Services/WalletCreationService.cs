using System.Threading.Tasks;
using Lykke.Service.EthereumSignService.Core.Domain;
using Lykke.Service.EthereumSignService.Core.Services;

namespace Lykke.Service.EthereumSignService.Services
{
    public class WalletCreationService : IWalletCreationService
    {
        public WalletCreationService()
        {

        }

        public async Task<KeyModel> CreateKeyModelAsync()
        {
            var key = Nethereum.Signer.EthECKey.GenerateKey();

            return new KeyModel()
            {
                PrivateKey = key.GetPrivateKey(),
                PublicAddress = key.GetPublicAddress().ToLower()
            };
        }
    }
}

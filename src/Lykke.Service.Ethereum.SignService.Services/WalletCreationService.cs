using System.Threading.Tasks;
using Lykke.Service.Ethereum.SignService.Core.Domain;
using Lykke.Service.Ethereum.SignService.Core.Services;

namespace Lykke.Service.Ethereum.SignService.Services
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
                PublicAddress = key.GetPublicAddress()
            };
        }
    }
}

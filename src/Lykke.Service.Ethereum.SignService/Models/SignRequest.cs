using Lykke.Service.Ethereum.SignService.Attributes;

namespace Lykke.Service.Ethereum.SignService.Models
{
    public class SignRequest
    {
        [PrivateKeyValidation]
        public string PrivateKey { get; set; }

        [TransactionHexValidation]
        public string TransactionHex { get; set; }
    }
}

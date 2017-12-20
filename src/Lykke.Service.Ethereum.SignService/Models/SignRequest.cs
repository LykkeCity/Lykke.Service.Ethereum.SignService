using Lykke.Service.Ethereum.SignService.Attributes;
using System.Runtime.Serialization;

namespace Lykke.Service.Ethereum.SignService.Models
{
    [DataContract]
    public class SignRequest
    {
        [DataMember(Name = "privateKey")]
        [PrivateKeyValidation]
        public string PrivateKey { get; set; }

        [DataMember(Name = "transactionHex")]
        [TransactionHexValidation]
        public string TransactionHex { get; set; }
    }
}

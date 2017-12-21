using Lykke.Service.Ethereum.SignService.Attributes;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Lykke.Service.Ethereum.SignService.Models
{
    [DataContract]
    public class SignRequest
    {
        [DataMember(Name = "privateKeys")]
        [PrivateKeyValidation]
        public IEnumerable<string> PrivateKeys { get; set; }

        [DataMember(Name = "transactionHex")]
        [TransactionHexValidation]
        public string TransactionHex { get; set; }
    }
}

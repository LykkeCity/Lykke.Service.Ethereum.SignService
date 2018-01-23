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

        [DataMember(Name = "transactionContext")]
        [TransactionHexValidation]
        public string TransactionContext { get; set; }
    }
}

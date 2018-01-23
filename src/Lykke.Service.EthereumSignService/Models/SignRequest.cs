using System.Collections.Generic;
using System.Runtime.Serialization;
using Lykke.Service.EthereumSignService.Attributes;

namespace Lykke.Service.EthereumSignService.Models
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

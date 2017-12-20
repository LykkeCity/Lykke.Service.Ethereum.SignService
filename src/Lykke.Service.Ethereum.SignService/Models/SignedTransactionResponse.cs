using System.Runtime.Serialization;

namespace Lykke.Service.Ethereum.SignService.Models
{
    [DataContract]
    public class SignedTransactionResponse
    {
        [DataMember(Name = "signedTransaction")]
        public string SignedTransaction{ get; set; }
    }
}

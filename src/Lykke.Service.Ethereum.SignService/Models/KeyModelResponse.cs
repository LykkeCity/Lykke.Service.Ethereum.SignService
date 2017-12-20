using System.Runtime.Serialization;

namespace Lykke.Service.Ethereum.SignService.Models
{
    [DataContract]
    public class KeyModelResponse
    {
        [DataMember(Name = "publicAddress")]
        public string PublicAddress { get; set; }

        [DataMember(Name = "privateKey")]
        public string PrivateKey { get; set; }
    }
}

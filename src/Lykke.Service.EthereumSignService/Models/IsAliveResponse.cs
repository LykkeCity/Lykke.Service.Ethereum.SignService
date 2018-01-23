using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Lykke.Service.EthereumSignService.Models
{
    [DataContract]
    public class IsAliveResponse
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "version")]
        public string Version { get; set; }

        [DataMember(Name = "env")]
        public string Env { get; set; }

        [DataMember(Name = "isDebug")]
        public bool IsDebug { get; set; }

        [DataMember(Name = "issueIndicators")]
        public IEnumerable<IssueIndicator> IssueIndicators { get; set; }

        [DataContract]
        public class IssueIndicator
        {
            [DataMember(Name = "type")]
            public string Type { get; set; }

            [DataMember(Name = "value")]
            public string Value { get; set; }
        }
    }
}

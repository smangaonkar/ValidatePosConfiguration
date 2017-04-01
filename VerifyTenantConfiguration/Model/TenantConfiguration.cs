using System.Collections.Generic;
using Newtonsoft.Json;

namespace VerifyTenantConfiguration.Model
{
    public class TenantConfiguration
    {
        [JsonProperty("client")]
        public List<Client> Client { get; set; }
    }
}

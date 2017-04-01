using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VerifyTenantConfiguration.Model
{
    public class Client
    {
        [JsonProperty("kenobiTenants")]
        public List<KenobiTenant> KenobiTenants { get; set; }
    }
}

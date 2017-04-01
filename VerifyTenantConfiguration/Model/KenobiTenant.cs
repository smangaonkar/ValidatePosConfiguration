using Newtonsoft.Json;

namespace VerifyTenantConfiguration.Model
{
    public class KenobiTenant
    {
        [JsonProperty("kenobiTenantId")]
        public string KenobiTenantId { get; set; }

        [JsonProperty("programId")]
        public string ProgramId { get; set; }

        [JsonProperty("programCode")]
        public string ProgramCode { get; set; }
    }
}

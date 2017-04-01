using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using VerifyTenantConfiguration.Model;

namespace VerifyTenantConfiguration.PosConfigurationDataProvider
{
    public static class PosConfigurationProvider
    {
        public static TenantConfiguration GetProdPosConfiguration()
        {
            var json =
                new JsonFileReader().GetResourceTextFile("VerifyTenantConfiguration.PosConfigurationDataProvider.ProposedJson.ProdPosConfiguration.json");
            try
            {
                var json1 = JsonConvert.DeserializeObject<TenantConfiguration>(json,
                 GetJsonSerializerSettings());
                return json1;
            }
            catch (Exception)
            {
                Console.WriteLine(ErrorMessages.ErrorMessages.InvalidJsonFormat);
                Console.WriteLine(ErrorMessages.ErrorMessages.DontPromoteToProd);
                Console.WriteLine(ErrorMessages.ErrorMessages.Exit);
                Console.ReadLine();
                return null;
            }

        }
        private static JsonSerializerSettings GetJsonSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }
    }
}

using System.Configuration;
using VerifyTenantConfiguration.ExcelSheetDataProvider;
using VerifyTenantConfiguration.TenantConfigurationDataProvider;
using VerifyTenantConfiguration.TenantConfigurationValidator;

namespace VerifyTenantConfiguration
{
    public class Program
    {
        static void Main(string[] args)
        {
            var excelSheetPath = GetExcelSheetPath();
            var prodTenantIdsProvider = new TenantIdProvider(excelSheetPath);
            var excelSheettenantIds = prodTenantIdsProvider.GetPRodTenantIds();
            var proposedTenantConfiguration = TenantConfigurationProvider.GetProdPosConfiguration();

            ProposedJsonValidator.ValidatePosConfiguration(excelSheettenantIds, proposedTenantConfiguration);
        }

        private static string GetExcelSheetPath()
        {
            var excelSheetPath = ConfigurationManager.AppSettings["ExcelSheetPath"];

            if (string.IsNullOrEmpty(excelSheetPath))
                throw new ConfigurationErrorsException("Please specify ExcelSheetPath in App.config");

            return excelSheetPath;
        }
    }
}

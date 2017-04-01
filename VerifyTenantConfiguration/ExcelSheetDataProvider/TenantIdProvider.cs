using System;
using System.Collections.Generic;
using Tavisca.Sceptr.TestSuite.Excel.Configuration;

namespace VerifyTenantConfiguration.ExcelSheetDataProvider
{
    public class TenantIdProvider
    {
        private static string _excelFilePath;

        public TenantIdProvider(string excelFilePath)
        {
            _excelFilePath = excelFilePath;
        }
        public List<string> GetPRodTenantIds()
        {
            var path = _excelFilePath;
            var excel = new ProviderFactory().GetProvider();
            var dataSet = excel.GetDataSet(path);
            return TenantIdParser.ParseTenantIdFromDataSet(dataSet);
        }
    }
}

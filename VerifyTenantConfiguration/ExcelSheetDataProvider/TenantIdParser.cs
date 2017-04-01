using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace VerifyTenantConfiguration.ExcelSheetDataProvider
{
    public static class TenantIdParser
    {
        public static List<string> ParseTenantIdFromDataSet(DataSet dataSet)
        {
            DataTable table = dataSet.Tables["TenantIds"];
            return table.Rows.Cast<DataRow>().Select(row => row["tenantid"].ToString()).ToList();
        }
    }
}

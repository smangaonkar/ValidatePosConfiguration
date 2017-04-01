using System;
using System.Collections.Generic;
using System.Linq;
using VerifyTenantConfiguration.Model;

namespace VerifyTenantConfiguration.PosConfigurationValidator
{
    public static class ProposedJsonValidator
    {
        public static void ValidatePosConfiguration(List<string> excelSheetTenantIds, TenantConfiguration proposedPosConfiguration)
        {
            int count = 0;
            var kenobiTenants = proposedPosConfiguration.Client.SelectMany(client => client.KenobiTenants).ToList();
            if (excelSheetTenantIds.Count != kenobiTenants.Count)
            {
                Console.WriteLine(ErrorMessages.ErrorMessages.TenantIdCountMismatch);
                Console.WriteLine(ErrorMessages.ErrorMessages.Filler);
                count++;
            }

            var tenantIds = kenobiTenants.Select(kenobiTenant => kenobiTenant.KenobiTenantId).ToList();
            if (excelSheetTenantIds.Except(tenantIds).Any())
            {
                var missingTenantIds = excelSheetTenantIds.Except(tenantIds).ToList();
                Console.WriteLine(ErrorMessages.ErrorMessages.MissingTenantIds);
                Console.WriteLine(ErrorMessages.ErrorMessages.Filler);
                missingTenantIds.ForEach(Console.WriteLine);
                Console.WriteLine(ErrorMessages.ErrorMessages.Filler);
                count++;
            }

            var tenantIdsMissingProgramIds = (from kenobiTenant in kenobiTenants where string.IsNullOrEmpty(kenobiTenant.ProgramId) select kenobiTenant.KenobiTenantId).ToList();
            if (tenantIdsMissingProgramIds.Count > 0)
            {
                Console.WriteLine(ErrorMessages.ErrorMessages.TenantIdsMissingProgramIds);
                Console.WriteLine(ErrorMessages.ErrorMessages.Filler);
                tenantIdsMissingProgramIds.ForEach(Console.WriteLine);
                Console.WriteLine(ErrorMessages.ErrorMessages.Filler);
                count++;
            }

            var tenantIdsMissingProgramCodes = (from kenobiTenant in kenobiTenants where string.IsNullOrEmpty(kenobiTenant.ProgramCode) select kenobiTenant.KenobiTenantId).ToList();
            if (tenantIdsMissingProgramIds.Count > 0)
            {
                Console.WriteLine(ErrorMessages.ErrorMessages.TenantIdsMissingProgramCodes);
                Console.WriteLine(ErrorMessages.ErrorMessages.Filler);
                tenantIdsMissingProgramCodes.ForEach(Console.WriteLine);
                Console.WriteLine(ErrorMessages.ErrorMessages.Filler);
                count++;
            }

            Console.WriteLine(count > 0
                ? ErrorMessages.ErrorMessages.DontPromoteToProd
                : ErrorMessages.ErrorMessages.ValidationSuccessful);
            Console.WriteLine(ErrorMessages.ErrorMessages.Exit);
            Console.ReadLine();
        }
    }
}

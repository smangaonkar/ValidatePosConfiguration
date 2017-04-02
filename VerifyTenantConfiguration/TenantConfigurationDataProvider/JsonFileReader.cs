using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerifyTenantConfiguration.TenantConfigurationDataProvider
{
    public class JsonFileReader
    {
        public string GetResourceTextFile(string filename)
        {
            using (var stream = GetType().Assembly.GetManifestResourceStream(filename))
            {
                return stream != null ? GetStreamString(stream) : string.Empty;
            }
        }

        private static string GetStreamString(Stream stream)
        {
            string result;
            using (var sr = new StreamReader(stream))
                result = sr.ReadToEnd();
            return result;
        }
    }
}

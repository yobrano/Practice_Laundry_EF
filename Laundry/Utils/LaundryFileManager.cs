using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laundry.Utils
{
    public class LaundryFileManager
    {

        public string GetImportFilePath(string fileName)
        {
            if (fileName.EndsWith(".json"))
            {
                throw new Exception("Can only import from Json files.");
            }
            return Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Data", "Imports", fileName);
        }

        public string GetExportFilePath(string fileName)
        {
            fileName = fileName.Trim();
            if (!fileName.EndsWith(".json"))
            {
                throw new Exception("Can only export to Json files.");
            }
            return Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Data", "Exports", fileName);
        }
    }
}

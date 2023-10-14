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
            fileName = fileName.Trim();
            if (!fileName.EndsWith(".json"))
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


        public string ReadImportFileContents(string fileName)
        {
            try{
                var filePath = this.GetImportFilePath(fileName);
                var fileContents = File.ReadAllText(filePath);
                return fileContents == null ? throw new Exception("There is no contents in the provide file.") : fileContents;
            }
            catch (Exception) { throw; }

        }


        public bool WriteExportFileContents(string fileName, string fileContent)
        {
            bool status;
            try{
                var filePath = this.GetExportFilePath(fileName);
                File.WriteAllText(filePath, fileContent);
                status = true;
            }catch (Exception) { throw; }
            return status;
        }
    }
}

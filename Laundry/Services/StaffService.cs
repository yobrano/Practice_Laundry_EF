using Laundry.Data;
using Laundry.Models;
using Laundry.Utils;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Laundry.Services
{
    public class StaffService
    {
        LaundryDBContext Context;
        LaundryFileManager FileManager = new LaundryFileManager();
        public StaffService(LaundryDBContext context) 
        {
            this.Context = context;
        }

        public Staff CreateStaff(int userId, string jobTitle) 
        {
            var staff = new Staff()
            {
                UserId = userId,
                JobTitle = jobTitle
            };
            this.Context.Add(staff);
            this.Context.SaveChanges();

            return staff;
        }

        // Import Staff
        public bool ImportStaff(string fileName)
        {
            // locatate and read the file.
            // Deserialize.
            // Commit to db.
            var status = false;
            var filePath = this.FileManager.GetImportFilePath(fileName);

            try
            {
                var fileContents = File.ReadAllText(filePath);
                var staffs = JsonConvert.DeserializeObject<List<Staff>>(fileContents);

                if(staffs == null) { return status;  }
                foreach(var staff in staffs)
                {
                    this.Context.Add(staff);
                }
                this.Context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                throw;
            }
            return status; 
        }



        // Export Staff
        public bool ExportStaff(string fileName)
        {
            // Get all staff
            // Serialize
            // Locate and write file.
            var status = false;
            var staffs = this.Context.Staff.ToList();
            try
            {
                var fileContents = JsonConvert.SerializeObject(staffs, Formatting.Indented);
                var filePath = this.FileManager.GetExportFilePath(fileName);
                File.WriteAllText(filePath, fileContents);
                status = true;
            }catch(Exception) { throw; }


            return status; 
        }

    }
}

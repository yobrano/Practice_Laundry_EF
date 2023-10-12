using Laundry.Data;
using Laundry.Models;
using Laundry.Utils;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;

namespace Laundry.Service
{
    public class UserService
    {
        LaundryDBContext Context;
        LaundryFileManager FileManger = new LaundryFileManager();

        public UserService(LaundryDBContext context) {
            this.Context = context;
        }
        
        // Create User (Default fields only)
        public User CreateUser(string firstName, string middleName, string lastName, string role)
        {
            var user = new User() 
            { 
              FirstName= firstName,
              MiddleName= middleName,
              LastName= lastName,
              Role= role
            };
            this.Context.User.Add(user);
            this.Context.SaveChanges();
            return user;
        }

        // Create User (all the fields)
        public User CreateUser(string firstName, string middleName, string lastName, string role, string email, string mobileNo, DateTime dob, string country, string county, string city, string estate, string town )
        {
            var user = new User() { 
                FirstName = firstName,
                MiddleName= middleName,
                LastName= lastName,
                Role= role,
                Email= email,
                MobileNo= mobileNo,
                DOB= dob,
                Country= country,
                County= county,
                City= city,
                Estate= estate,
                Town= town

            };
            
            this.Context.User.Add(user);
            this.Context.SaveChanges();
            return user;
        }

        // Import and Export of User Lists
        public List<User> ImportUsers(string fileName)
        {
            var path = this.FileManger.GetImportFilePath(fileName);
            try
            {
                var fileContents = File.ReadAllText(path);
                var users = JsonConvert.DeserializeObject<List<User>>(fileContents);
                if(users == null) { return new List<User>(); }
                
                // Commit users to DB.
                try
                {
                    foreach(var user in users)
                    {
                        this.Context.User.Add(user);
                    }   
                    this.Context.SaveChanges(); 
                }catch(Exception )
                {
                    throw;
                }
                return users;
            }
            catch(Exception )
            {
                throw;
               
            }
        }


        public bool ExportUsers(string fileName)
        {
            var status = false;
            var users = this.Context.User.ToList();
            var path = this.FileManger.GetExportFilePath(fileName);
            try
            {
                var fileContents = JsonConvert.SerializeObject(users, Formatting.Indented);
                File.WriteAllText(path, fileContents);
            }catch(Exception)
            {
                throw ;
            }
            return status;
        }

    }
}

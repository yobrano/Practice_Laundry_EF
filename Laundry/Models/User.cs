using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Laundry.Models
{

    [Index(nameof(User.Email), IsUnique = true)]
    [Index(nameof(User.MobileNo), IsUnique = true)]
    [Index(nameof(User.FirstName), nameof(User.MiddleName), nameof(User.LastName), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Role { get; set; } = null!;
        
        [EmailAddress]
        public string? Email { get; set; } 
        public string? MobileNo { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }
        public string? Country { get; set; }
        public string? County { get; set; }
        public string? City { get; set; }
        public string? Estate { get; set; }
        public string? Town { get; set; }

    }
}

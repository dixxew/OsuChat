using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ChatWebServer.Models
{
    public class User : IdentityUser
    {        
        public string? ImageSource { get; set; }
        public string? UserChats { get; set; }
        public string? GroupChats { get; set; }
    }  
    
}

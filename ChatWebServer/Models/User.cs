using Microsoft.AspNetCore.Identity;

namespace ChatWebServer.Models
{
    public class User : IdentityUser
    {        
        public string ImageSource { get; set; }
        public List<WithUser> UserChats { get; set; }
        public List<WithGroup> GroupChats { get; set; }
    }
    public class WithUser
    {
        public int ChatId { get; set; }
        public int UnreadCount { get; set; }
        public string LastReaded { get; set; }
    }
    public class WithGroup
    {
        public int ChatId { get; set; }
        public int UnreadCount { get; set; }
        public string LastReaded { get; set; }
    }
}

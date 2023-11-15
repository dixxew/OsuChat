namespace ChatWebServer.Models
{
    public class ChatWithUser
    {
        public int ChatId { get; set; }
        public int UnreadCount { get; set; }
        public string LastReaded { get; set; }
    }
}

namespace ChatWebServer.Models
{
    public class MessageStoreDBSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string MessagesCollectionName { get; set; } = null!;
    }
}

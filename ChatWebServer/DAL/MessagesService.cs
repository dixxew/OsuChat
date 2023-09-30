using ChatWebServer.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ChatWebServer.DAL
{
    public class MessagesService
    {
        private readonly IMongoCollection<Message> _messagesCollection;

        public MessagesService(
            IOptions<MessageStoreDBSettings> messageStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                messageStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                messageStoreDatabaseSettings.Value.DatabaseName);

            _messagesCollection = mongoDatabase.GetCollection<Message>(
                messageStoreDatabaseSettings.Value.MessagesCollectionName);
        }

        public async Task<List<Message>> GetAsync() =>
            await _messagesCollection.Find(_ => true).ToListAsync();

        public async Task<Message?> GetAsync(string id) =>
            await _messagesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Message newMessage) =>
            await _messagesCollection.InsertOneAsync(newMessage);

        public async Task UpdateAsync(string id, Message updatedMessage) =>
            await _messagesCollection.ReplaceOneAsync(x => x.Id == id, updatedMessage);

        public async Task RemoveAsync(string id) =>
            await _messagesCollection.DeleteOneAsync(x => x.Id == id);
    }
}

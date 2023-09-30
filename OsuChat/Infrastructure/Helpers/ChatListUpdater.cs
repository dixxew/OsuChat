using OsuChat.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuChat.Infrastructure.Helpers
{
    class ChatListUpdater
    {
        public ChatModel UpdateChatList(int chat_id, bool is_group)
        {
            ChatModel chatModel = new ChatModel();
            chatModel.ChatId = chat_id;
            chatModel.IsGroup = is_group;            
            BckgDataUpdater(chatModel);
            return chatModel;
        }

        private async void BckgDataUpdater(ChatModel cm)
        {
            //запросы на сервер
        }
    }
}

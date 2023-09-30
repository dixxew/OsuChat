using OsuChat.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuChat.Infrastructure.Helpers
{
    class MessageListUpdater
    {
        public MessageModel UpdateMessageList(int chat_id, int from_id, string message_text, DateTime time)
        {
            MessageModel messageModel = new MessageModel();
            messageModel.ChatId = chat_id;
            messageModel.UserId = from_id;
            messageModel.MessageText = message_text;
            messageModel.Time = time;
            BckgDataUpdater(messageModel);
            return messageModel;
        }

        private async void BckgDataUpdater(MessageModel mm)
        {
            //запросы на сервер
        }
    }
}

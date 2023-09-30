using OsuChat.Core;
using OsuChat.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Microsoft.AspNetCore.SignalR.Client;
using System.Windows.Threading;
using System.Windows;
using OsuChat.Infrastructure.Helpers;

namespace OsuChat.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        #region props
        private ObservableCollection<MessageModel> _messages;
        public ObservableCollection<MessageModel> Messages
        {
            get { return _messages; }
            set { _messages = value; }
        }


        private ObservableCollection<ChatModel> _chats;
        public ObservableCollection<ChatModel> Chats
        {
            get { return _chats; }
            set { _chats = value; }
        }

        private ChatModel _selectedChat;
        public ChatModel SelectedChat
        {
            get { return _selectedChat; }
            set
            {
                _selectedChat = value;
                OnPropertyChanged();
            }
        }


        private string _inputMessage;
        public string InputMessage
        {
            get { return _inputMessage; }
            set
            {
                _inputMessage = value;
                OnPropertyChanged();
            }
        }


        private int _selectedMessageIndex;
        public int SelectedMessageIndex
        {
            get { return _selectedMessageIndex; }
            set { _selectedMessageIndex = value; OnPropertyChanged(); }
        }
        #endregion

        #region cfg 
        HubConnection connection;
        string chatUrl = "http://localhost:57725/hubLink";
        #endregion

        #region commands
        public RelayCommand SendCommand { get; set; }

        #endregion

        Profile me;

        public async void SendMessage(int chat_id, int from_id, int to_id, string message_text, DateTime time)
        {
            await connection.SendAsync("SendMessageAsync", from_id, to_id, message_text, time);
        }

        public MainViewModel()
        {
            ChatListUpdater ChatsUpdater = new ChatListUpdater();
            MessageListUpdater MessagesUpdater = new MessageListUpdater();
            me = new Profile();
            Messages = new ObservableCollection<MessageModel>();
            Chats = new ObservableCollection<ChatModel>();
            SendCommand = new RelayCommand(o =>
            {
                SendMessage(me.Id, 1, InputMessage, DateTime.Now);
                SelectedMessageIndex = Messages.Count() - 1;
                InputMessage = "";
            });
            connection = new HubConnectionBuilder()
                .WithUrl(chatUrl)
                .Build();
            connection.StartAsync();

            connection.On<int, bool>("UpdateChatsAsync", (chat_id, is_group) =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Chats.Add(ChatsUpdater.UpdateChatList(chat_id,is_group));
                });
            });
            connection.On<int ,int, string, DateTime>("SendMessageAsync", (chat_id, from_id, message_text, time) =>
            {
                Application.Current.Dispatcher.Invoke( () =>
                {
                    Messages.Add(MessagesUpdater.UpdateMessageList(chat_id, from_id, message_text, time));
                });
            });
        }
    }
}

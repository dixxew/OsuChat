using Microsoft.AspNetCore.SignalR.Client;
using OsuChat.Core;
using OsuChat.Infrastructure.Helpers;
using OsuChat.MVVM.View;
using OsuChat.MVVM.Model;
using OsuChat.Store;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using OsuChat.Services;
using OsuChat.Command;
using System.Diagnostics;

namespace OsuChat.MVVM.ViewModel;

public class ChatViewModel : Core.ViewModel
{
    #region props

    private Profile _profile;

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

   

    private SideMenuViewModel _sdeMenuDataContext;

    public SideMenuViewModel SideMenuDataContext
    {
        get { return _sdeMenuDataContext; }
        set { _sdeMenuDataContext = value; OnPropertyChanged(); }
    }


    #endregion

    #region cfg 
    HubConnection connection;
    string chatUrl = "http://localhost:57725/hubLink";
    #endregion

    #region commands
    public RelayCommand SendCommand { get; set; }
    public RelayCommand SideMenuCommand { get; set; }

    #endregion


    public async void SendMessage(int chat_id, string from_id, string to_id, string message_text, DateTime time)
    {
        await connection.SendAsync("SendMessageAsync", from_id, to_id, message_text, time);
    }

    

    public ChatViewModel(ApplicationStore appStore, Profile profile)
    {
        SideMenuDataContext = new SideMenuViewModel(profile, appStore.SideMenuStore);
        SideMenuCommand = new RelayCommand( o =>
        {
            appStore.SideMenuStore.ShowSideMenu();
        }); 
        ChatListUpdater ChatsUpdater = new ChatListUpdater();
        MessageListUpdater MessagesUpdater = new MessageListUpdater();
        Messages = new ObservableCollection<MessageModel>();
        Chats = new ObservableCollection<ChatModel>();
        SendCommand = new RelayCommand(o =>
        {
            SendMessage(SelectedChat.ChatId, profile.Id, "sdfsdf", InputMessage, DateTime.Now);
            SelectedMessageIndex = Messages.Count - 1;
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
                Chats.Add(ChatsUpdater.UpdateChatList(chat_id, is_group));
            });
        });
        connection.On<int, int, string, DateTime>("SendMessageAsync", (chat_id, from_id, message_text, time) =>
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                Messages.Add(MessagesUpdater.UpdateMessageList(chat_id, from_id, message_text, time));
            });
        });
    }
}

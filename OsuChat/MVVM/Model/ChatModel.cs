using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace OsuChat.MVVM.Model;

public class ChatModel
{
    public int ChatId { get; set; }
    public string Chatname { get; set; }
    public bool IsGroup { get; set; }
    public string ImageSource { get; set; }
    public ObservableCollection<MessageModel> Messages { get; set; }  

    //ChatCard
    public string LastMessage => Messages.Last().MessageText;
    public DateTime Time => Messages.Last().Time;
    public bool IsLastMessageToday
    {
        get
        {
            if ((Time - DateTime.Now).Days != 0) return false;
            else return true;
        }
    }
}    

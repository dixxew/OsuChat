using System;

namespace OsuChat.MVVM.Model;

public class MessageModel
{
    public int MessageId { get; set; }
    public string MessageText { get; set; }
    public int UserId { get; set; }
    public int ChatId { get; set; }
    public string ImageSource { get; set; } 
    public string Username { get; set; }
    public string UsernameColor { get; set; }
    public DateTime Time { get; set; }
    public bool FirstMessage { get; set; }
}

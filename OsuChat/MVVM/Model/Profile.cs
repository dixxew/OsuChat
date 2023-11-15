namespace OsuChat.MVVM.Model;

public class Profile
{
    public bool IsAuthorized { get; set; } = false;
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? ImageSource { get; set; } = "https://hownot2code.files.wordpress.com/2016/07/ms-net.png";
    public string? Token { get; set; }
}

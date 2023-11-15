using OsuChat.Command;
using OsuChat.Core;
using OsuChat.MVVM.Model;
using OsuChat.Services;
using OsuChat.Store;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OsuChat.MVVM.ViewModel;

public class AuthViewModel : Core.ViewModel
{
    HttpClient client = new HttpClient();

    #region props
    public bool LoginIsRunning { get; set; }
    private string _name = "string1";
    public string Name
    {
        get { return _name; }
        set { _name = value; OnPropertyChanged(); }
    }

    private string _password = "String1";
    public string Password
    {
        get { return _password; }
        set { _password = value; OnPropertyChanged(); }
    }
    #endregion
    #region commands
    public ICommand NavigateChatCommand { get; }
    public ICommand NavigateRegCommand { get; } 
    #endregion

    public AuthViewModel(ApplicationStore appStore)
    {
        Profile profile = new Profile();
        NavigateChatCommand = new LoginCommand(this,new NavigationService<ChatViewModel>(appStore.NavigationStore, () => new ChatViewModel(appStore, profile)));
        NavigateRegCommand = new ToRegCommand(new NavigationService<RegViewModel>(appStore.NavigationStore, () => new RegViewModel(appStore)));
    }

    public async Task Login()
    {
        if (LoginIsRunning)
            return;

        try
        {
            LoginIsRunning = true;
        }
        catch { }
        finally
        {
            LoginIsRunning = false;
        }
    }
}

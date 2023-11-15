using OsuChat.Command;
using OsuChat.Core;
using OsuChat.MVVM.Model.Auth;
using OsuChat.MVVM.View;
using OsuChat.Services;
using OsuChat.Store;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;
using System.Windows.Controls;

namespace OsuChat.MVVM.ViewModel;

public class RegViewModel : Core.ViewModel
{
    HttpClient client = new HttpClient();

    #region props
    private Visibility _visibility;

    public Visibility Visibility
    {
        get { return _visibility; }
        set { _visibility = value; OnPropertyChanged(); }
    }


    private string _name = "string1";
    public string Name
    {
        get { return _name; }
        set { _name = value; OnPropertyChanged(); }
    }

    private string _email = "string1";
    public string Email
    {
        get { return _email; }
        set { _email = value; OnPropertyChanged(); }
    }

    private string _password = "String1";
    public string Password
    {
        get { return _password; }
        set { _password = value; OnPropertyChanged(); }
    }

    private string _confirmPassword = "String1";
    public string ConfirmPassword
    {
        get { return _confirmPassword; }
        set { _confirmPassword = value; OnPropertyChanged(); }
    }
    #endregion
    #region commands
    public RelayCommand RegisterCommand { get; } 
    public ToLoginCommand ToAuthCommand { get; }
    #endregion

    public RegViewModel(ApplicationStore appStore)
    {
        RegisterCommand = new RelayCommand(o =>
        {
            if (Password == ConfirmPassword)
            {
                Reg reg = new Reg { Password = Password, Email = Email, Name = Name };
                JsonContent content = JsonContent.Create(reg);
                var resp = client.PostAsync("https://localhost:7094/reg", content);
                MessageBox.Show(resp.Result.Content.ReadAsStringAsync().Result);
                Visibility = Visibility.Hidden;
            } else
            {
                MessageBox.Show("Passwords dont match");
            }            
        });
        ToAuthCommand = new ToLoginCommand(new NavigationService<AuthViewModel>(appStore.NavigationStore, () => new AuthViewModel(appStore)));
    }
}

using OsuChat.MVVM.ViewModel;
using OsuChat.Services;

namespace OsuChat.Command;

public class ToLoginCommand : CommandBase
{
    private readonly INavigationService _navigationService;

    public ToLoginCommand(NavigationService<AuthViewModel> navigationService)
    {
        _navigationService = navigationService;
    }

    public override void Execute(object parameter)
    {
        _navigationService.Navigate();
    }
}
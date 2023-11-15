using OsuChat.Services;
using System.Windows.Navigation;

namespace OsuChat.Command;

public class NavigationCommand : CommandBase
{
    private readonly INavigationService _navigationService;

    public NavigationCommand(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    public override void Execute(object parameter)
    {
        _navigationService.Navigate();
    }
}

using OsuChat.MVVM.ViewModel;
using OsuChat.Services;

namespace OsuChat.Command;

public class ToRegCommand : CommandBase
{
    private readonly INavigationService _navigationService;

    public ToRegCommand(NavigationService<RegViewModel> navigationService)
    {
        _navigationService = navigationService;
    }

    public override void Execute(object parameter)
    {
        _navigationService.Navigate();
    }
}
using OsuChat.MVVM.ViewModel;
using OsuChat.Services;

namespace OsuChat.Command;

public class SideMenuCommand : CommandBase
{
    private readonly ChatViewModel _viewModel;
    private readonly INavigationService _navigationService;

    public SideMenuCommand(ChatViewModel viewModel, NavigationService<AuthViewModel> navigationService)
    {
        _viewModel = viewModel;
        _navigationService = navigationService;
    }

    public override void Execute(object parameter)
    {
        _navigationService.Navigate();
    }
}

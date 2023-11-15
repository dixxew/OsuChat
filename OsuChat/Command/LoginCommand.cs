using OsuChat.MVVM.ViewModel;
using OsuChat.Services;

namespace OsuChat.Command;

public class LoginCommand : CommandBase
{
    private readonly AuthViewModel _viewModel;
    private readonly INavigationService _navigationService;

    public LoginCommand(AuthViewModel viewModel, NavigationService<ChatViewModel> navigationService)
    {
        _viewModel = viewModel;
        _navigationService = navigationService;
    }

    public override void Execute(object parameter)
    {
        _navigationService.Navigate();
    }
}
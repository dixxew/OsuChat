using OsuChat.Core;
using OsuChat.MVVM.View;
using OsuChat.MVVM.Model;
using OsuChat.Store;

namespace OsuChat.MVVM.ViewModel;

public class MainViewModel : Core.ViewModel
{
    private readonly NavigationStore _navigationStore;
    
    public Core.ViewModel CurrentViewModel => _navigationStore.CurrentViewModel;

    public MainViewModel(ApplicationStore appStore, Profile prof)
    {
        _navigationStore = appStore.NavigationStore;

        _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

        _navigationStore.CurrentViewModel = new AuthViewModel(appStore);
    }

    private void OnCurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }

}

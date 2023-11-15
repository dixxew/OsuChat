using OsuChat.Core;
using OsuChat.MVVM.Model;
using OsuChat.Store;
using System.Windows;

namespace OsuChat.MVVM.ViewModel;

public class SideMenuViewModel : Core.ViewModel
{
	private string _profileImage;
	public string ProfileImage
    {
		get { return _profileImage; }
		set { _profileImage = value; OnPropertyChanged(); }
	}

    private string _profileName;
    public string ProfileName
    {
        get { return _profileName; }
        set { _profileName = value; OnPropertyChanged(); }
    }


    private readonly SideMenuStore _sideMenuStore;

    public Visibility SideMenuVisibility => _sideMenuStore.SideMenuVisility;




    public RelayCommand CloseSideMenuCommand {  get; set; }


    public SideMenuViewModel(Profile profile, SideMenuStore sideMenuStore)
    {
        _sideMenuStore = sideMenuStore;
        _sideMenuStore.SideMenuVisilityChanged += SideMenuVisibilityChanged;
        ProfileName = profile.Name;
        ProfileImage = profile.ImageSource;
        CloseSideMenuCommand = new RelayCommand(o =>
        {
            _sideMenuStore.HideSideMenu();
        });
    }    

    private void SideMenuVisibilityChanged()
    {
        OnPropertyChanged(nameof(SideMenuVisibility));
    }
}

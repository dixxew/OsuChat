using OsuChat.Core;
using System;
using System.Windows;

namespace OsuChat.Store;

public class SideMenuStore
{
    private Visibility _sideMenuVisility;
    public Visibility SideMenuVisility => _sideMenuVisility;

    public event Action SideMenuVisilityChanged;

    private void OnSideMenuVisilityChanged()
    {
        SideMenuVisilityChanged?.Invoke();
    }

    public SideMenuStore()
    {
        _sideMenuVisility = Visibility.Hidden;
    }

    public void ShowSideMenu()
    {
        _sideMenuVisility = Visibility.Visible;
        OnSideMenuVisilityChanged();
    }

    public void HideSideMenu()
    {
        _sideMenuVisility = Visibility.Hidden;
        OnSideMenuVisilityChanged();
    }
}

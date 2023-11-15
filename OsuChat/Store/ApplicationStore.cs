namespace OsuChat.Store;

public class ApplicationStore
{
	private NavigationStore _navStore;

	public NavigationStore NavigationStore
	{
		get { return _navStore; }
		set { _navStore = value; }
	}

	private SideMenuStore _sideMenuStore;

	public SideMenuStore SideMenuStore
	{
		get { return _sideMenuStore; }
		set { _sideMenuStore = value; }
	}

	public ApplicationStore(NavigationStore navStore, SideMenuStore sideMenuStore)
    {
        _navStore = navStore;
		_sideMenuStore = sideMenuStore;
    }
}

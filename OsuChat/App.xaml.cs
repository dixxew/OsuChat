using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OsuChat.Core;
using OsuChat.MVVM.View;
using OsuChat.MVVM.Model;
using OsuChat.MVVM.ViewModel;
using OsuChat.Store;
using System.Windows;

namespace OsuChat;

public partial class App : Application
{
    public static IHost? AppHost { get; private set; }

    public App()
    {
        AppHost = Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                //store
                services.AddSingleton<ApplicationStore>();
                services.AddSingleton<Profile>();
                services.AddSingleton<NavigationStore>();
                services.AddSingleton<SideMenuStore>();


                //viewModels
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<AuthViewModel>();
                services.AddSingleton<ChatViewModel>();
                services.AddSingleton<RegViewModel>();



                services.AddSingleton<MainWindow>(s => new MainWindow()
                {
                    DataContext = s.GetRequiredService<MainViewModel>()
                });
            })
            .Build();
    }
    protected override async void OnStartup(StartupEventArgs e)
    {
        await AppHost!.StartAsync();

        MainWindow = AppHost.Services.GetRequiredService<MainWindow>();        
        MainWindow.Show();

        base.OnStartup(e);
    }
    protected override async void OnExit(ExitEventArgs e)
    {
        await AppHost.StopAsync();

        base.OnExit(e);
    }        
}

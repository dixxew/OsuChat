using System.Windows.Controls;

namespace OsuChat.MVVM.View;
public partial class ChatControl : UserControl
{
    public ChatControl()
    {
        InitializeComponent();
    }

    private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ListView lv = sender as ListView;
        lv.ScrollIntoView(lv.SelectedItem);
    }
}

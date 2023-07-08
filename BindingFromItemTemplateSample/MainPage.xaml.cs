using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;

namespace BindingFromItemTemplateSample;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();
    }

    public MainViewModel ViewModel { get; } = new();

    private void ComboBox_Loaded(object sender, RoutedEventArgs e)
    {
        if (sender is ComboBox comboBox)
        {
            comboBox.SetBinding(
                ComboBox.ItemsSourceProperty,
                new Binding
                {
                    Source = ViewModel,
                    Path = new PropertyPath("Options"),
                    Mode = BindingMode.OneWay,
                });
        }
    }

    private void Button_Loaded(object sender, RoutedEventArgs e)
    {
        if (sender is Button button &&
            button.Command is null)
        {
            button.Command = ViewModel.ResetOptionCommand;
        }
    }

    private void ItemsRepeater_ElementPrepared(ItemsRepeater sender, ItemsRepeaterElementPreparedEventArgs args)
    {
        if (args.Element is FrameworkElement frameworkElement &&
            args.Index >= 0 &&
            args.Index < sender.ItemsSourceView.Count)
        {
            frameworkElement.DataContext = sender.ItemsSourceView.GetAt(args.Index);
        }
    }
}

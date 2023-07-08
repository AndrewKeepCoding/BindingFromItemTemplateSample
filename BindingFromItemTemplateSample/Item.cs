using CommunityToolkit.Mvvm.ComponentModel;

namespace BindingFromItemTemplateSample;

public partial class Item : ObservableObject
{
    [ObservableProperty]
    private int id;

    [ObservableProperty]
    private string? option;
}

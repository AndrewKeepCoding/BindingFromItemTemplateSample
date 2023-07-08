using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BindingFromItemTemplateSample;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Item> items = new();

    [ObservableProperty]
    private List<string> options = new()
    {
        "Option A",
        "Option B",
        "Option C",
    };

    [RelayCommand]
    private void UpdateItemsCount(int itemsCount)
    {
        int newItemsCount = Math.Max(itemsCount, 0);

        if (Items.Count < newItemsCount)
        {
            for (int i = Items.Count; i < newItemsCount; i++)
            {
                Items.Add(new Item { Id = i + 1 });
            }
        }
        else if (Items.Count > newItemsCount)
        {
            for (int i = Items.Count - 1; i >= newItemsCount; i--)
            {
                Items.RemoveAt(i);
            }
        }
    }

    [RelayCommand]
    private void ResetOption(Item item)
    {
        if (item is null)
        {
            return;
        }

        item.Option = null;
    }
}

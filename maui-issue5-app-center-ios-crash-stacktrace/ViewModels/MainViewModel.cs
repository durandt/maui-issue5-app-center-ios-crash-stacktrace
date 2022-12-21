using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using maui_issue5_app_center_ios_crash_stacktrace.ViewModels.Base;

namespace maui_issue5_app_center_ios_crash_stacktrace.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private bool _fixBug;

    public string ItemsCountLabel => $"Results contain {Items.Count} item{(Items.Count > 1 ? "s" : "")}";

    public ObservableCollection<string> Items { get; } = new();

    private readonly string[] _data = { "The", "Quick", "Brown", "Fox", "Jumps", "Over", "The", "Lazy", "Dog" };

    public MainViewModel()
    {
        Items.CollectionChanged += (_, _) =>
        {
            base.OnPropertyChanged(new PropertyChangedEventArgs(nameof(ItemsCountLabel)));
        };
    }

    public void AddItem()
    {
        var currentCount = Items.Count;
        Items.Add($"{currentCount + 1}: " + _data[currentCount % _data.Length]);
    }
}
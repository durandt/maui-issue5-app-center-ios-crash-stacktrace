using System.ComponentModel;
using maui_issue5_app_center_ios_crash_stacktrace.ViewModels;

namespace maui_issue5_app_center_ios_crash_stacktrace;

public partial class MainPage : ContentPage
{
    private MainViewModel MainViewModel { get; }

	public MainPage(MainViewModel mainViewModel)
	{
		InitializeComponent();
		BindingContext = mainViewModel;
        MainViewModel = mainViewModel;
    }

    private void GenerateCrashButton_OnClicked(object sender, EventArgs eventArgs)
    {
        var exc = new ApplicationException();
        try
        {
            throw new ApplicationException("test");
        }
        catch (ApplicationException e)
        {
            exc = e;
        }
        var stacktrace1 = exc.StackTrace;
        var stacktrace2 = System.Environment.StackTrace;
        var myArray = Array.Empty<string>();
        var myString = myArray[0]; // Will throw System.IndexOutOfRangeException
    }

    private async void GenerateCrashAsyncButton_OnClicked(object sender, EventArgs eventArgs)
    {
        await Task.Delay(10);
        var exc = new ApplicationException();
        try
        {
            throw new ApplicationException("test");
        }
        catch (ApplicationException e)
        {
            exc = e;
        }
        var stacktrace1 = exc.StackTrace;
        var stacktrace2 = System.Environment.StackTrace;
        var myArray = Array.Empty<string>();
        var myString = myArray[0]; // Will throw System.IndexOutOfRangeException
    }
}



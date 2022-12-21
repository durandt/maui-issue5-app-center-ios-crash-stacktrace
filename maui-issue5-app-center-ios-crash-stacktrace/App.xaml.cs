using maui_issue5_app_center_ios_crash_stacktrace.ViewModels;

namespace maui_issue5_app_center_ios_crash_stacktrace;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new MainPage(new MainViewModel()));
	}
}


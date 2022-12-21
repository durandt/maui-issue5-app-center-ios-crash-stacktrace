using System;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace maui_issue5_app_center_ios_crash_stacktrace;

class Program : MauiApplication
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

	static void Main(string[] args)
	{
		var app = new Program();
		app.Run(args);
	}
}


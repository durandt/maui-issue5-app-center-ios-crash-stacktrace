using System;
namespace maui_issue5_app_center_ios_crash_stacktrace.ViewModels.Base;

public interface IViewModel
{
    public bool IsInitialized { get; set; }
    public bool IsBusy { get; }

    Task InitializeAsync();
}


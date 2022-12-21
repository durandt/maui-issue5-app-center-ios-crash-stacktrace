## Title

[iOS] Stacktrace from crashes initiated from Button.Clicked and synchronous code lack relevant
stacktrace information

## Description

On iOS, crashes that are initiated from a `Button.Clicked`  event using a synchronous delegate
point to application entry point in AppDelegate.cs and lack some relevant stacktrace
information, making troubleshooting much harder.

This bug does not seem to affect Android, and only affects iOS synchronous delegate. This
bug does not appear when using an asynchronous delegate to handle the `Button.Clicked` event.

This bug seems to affect both .NET 6 and latest .NET 7 and could be reproduced on iOS 16.2 and
iOS 15.5, using Xcode 14.2

## Github issues

* dotnet/maui#12853

## Steps to Reproduce

* Run the attached sample on iOS
* Hit the _Generate crash_ Button
* Check the Stacktrace in logs (missing information):

```
Unhandled Exception:
System.IndexOutOfRangeException: Index was outside the bounds of the array.
   at ObjCRuntime.Runtime.ThrowException(IntPtr gchandle)
   at UIKit.UIApplication.UIApplicationMain(Int32 argc, String[] argv, IntPtr principalClassName, IntPtr delegateClassName)
   at UIKit.UIApplication.Main(String[] args, Type principalClass, Type delegateClass)
   at maui_issue5_app_center_ios_crash_stacktrace.Program.Main(String[] args) in /Users/thidu06/projects/maui/maui-issue5-app-center-ios-crash-stacktrace/maui-issue5-app-center-ios-crash-stacktrace/Platforms/iOS/Program.cs:line 13
```

* Re-un the attached sample on iOS
* Hit the _Generate crash async_ Button
* Check the Stacktrace in logs (has all information):

```
Unhandled Exception:
System.IndexOutOfRangeException: Index was outside the bounds of the array.
   at maui_issue5_app_center_ios_crash_stacktrace.MainPage.GenerateCrashAsyncButton_OnClicked(Object sender, EventArgs eventArgs) in /Users/thidu06/projects/maui/maui-issue5-app-center-ios-crash-stacktrace/maui-issue5-app-center-ios-crash-stacktrace/MainPage.xaml.cs:line 54
   at ObjCRuntime.Runtime.ThrowException(IntPtr gchandle)
   at UIKit.UIApplication.UIApplicationMain(Int32 argc, String[] argv, IntPtr principalClassName, IntPtr delegateClassName)
   at UIKit.UIApplication.Main(String[] args, Type principalClass, Type delegateClass)
   at maui_issue5_app_center_ios_crash_stacktrace.Program.Main(String[] args) in /Users/thidu06/projects/maui/maui-issue5-app-center-ios-crash-stacktrace/maui-issue5-app-center-ios-crash-stacktrace/Platforms/iOS/Program.cs:line 13
```

* This time the first line of the stacktrace points to the relevant code line.

## Link to public reproduction project repository

https://github.com/durandt/maui-issue5-app-center-ios-crash-stacktrace

## Version with bug
7.0.102 (current)

## Last version that worked well
Unknown

## Affected platforms
iOS

## Affected platform versions
iOS 16.2

## Did you find any workaround?

Using asynchronous delegates seems to work but that does not seem practical.

I have tried wrapping the test-crash code into a method but this does not help. 

## Relevant log output


```
2023-01-19 13:41:55.720442+0100 maui-issue5-app-center-ios-crash-stacktrace[30548:13668628] 
Unhandled Exception:
System.IndexOutOfRangeException: Index was outside the bounds of the array.
   at ObjCRuntime.Runtime.ThrowException(IntPtr gchandle)
   at UIKit.UIApplication.UIApplicationMain(Int32 argc, String[] argv, IntPtr principalClassName, IntPtr delegateClassName)
   at UIKit.UIApplication.Main(String[] args, Type principalClass, Type delegateClass)
   at maui_issue5_app_center_ios_crash_stacktrace.Program.Main(String[] args) in /Users/thidu06/projects/maui/maui-issue5-app-center-ios-crash-stacktrace/maui-issue5-app-center-ios-crash-stacktrace/Platforms/iOS/Program.cs:line 13


```
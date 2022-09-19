using Microsoft.Maui.Platform;
using Firebase.Database;

namespace Assignment1;

public partial class App : Application
{


    public static FirebaseClient client = new("https://myfirstdb-f4b55-default-rtdb.asia-southeast1.firebasedatabase.app/");
    public App()
    {
        InitializeComponent();

        //		Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(Border), (handler, view) =>
        //		{
        //			if (view is Border)
        //			{
        //#if __ANDROID__
        //				handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());

        //#elif __IOS__
        //                 handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
        //#endif

        //			}
        //		});

        MainPage = new NavigationPage(new Pages.WelcomePage());
    }
}

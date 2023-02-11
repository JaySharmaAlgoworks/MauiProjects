using Foundation;
using SQLitePCL;

namespace CarListingApp;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp()
    {
       // SQLitePCL.raw.SetProvider(new SQLite3Provider_dynamic_cdecl());
        return MauiProgram.CreateMauiApp(); 
    }
}


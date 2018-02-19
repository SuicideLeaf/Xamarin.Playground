using Foundation;
using MvpArchitecture.iOS.Classes;

namespace Landlord.iOS.Classes
{
	public static class UserDefaults
	{
		public static bool IsAuthenticated => NSUserDefaults.StandardUserDefaults.BoolForKey( Constants.DefaultKeys.IsAuthenticated );
		public static string InstanceUrl => NSUserDefaults.StandardUserDefaults.StringForKey( Constants.DefaultKeys.InstanceUrl );

		public static void SetIsAuthenticated( bool isAuthenticated )
		{
			NSUserDefaults.StandardUserDefaults.SetBool( isAuthenticated, Constants.DefaultKeys.IsAuthenticated );
		}

		public static void SetInstanceUrl( string instanceUrl )
		{
			NSUserDefaults.StandardUserDefaults.SetString( instanceUrl, Constants.DefaultKeys.InstanceUrl );
		}
	}
}

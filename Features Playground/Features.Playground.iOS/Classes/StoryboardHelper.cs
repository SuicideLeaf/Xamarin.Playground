using Foundation;
using UIKit;

namespace Features.Playground.iOS.Classes
{
	public static class StoryboardHelper
	{
		public static T GetViewController<T>( string storyboardName, string viewControllerIdentifier )
			where T : UIViewController
		{
			return ( T )UIStoryboard.FromName( storyboardName, NSBundle.MainBundle ).InstantiateViewController( viewControllerIdentifier );
		}
	}
}
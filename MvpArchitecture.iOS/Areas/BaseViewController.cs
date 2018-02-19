using System;
using MvpArchitecture.Areas;
using UIKit;
using Unity;

namespace MvpArchitecture.iOS.Areas
{
	public abstract class BaseViewController<T> : UIViewController, IBaseView
	where T : BasePresenter
	{
		public T Presenter { get; set; }
		public abstract void RegisterView( );

		internal BaseViewController( IntPtr handle ) : base( handle ) { }

		public override void ViewDidLoad( )
		{
			base.ViewDidLoad( );
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning( )
		{
			base.DidReceiveMemoryWarning( );
			// Release any cached data, images, etc that aren't in use.
		}

		public void SetPresenter( )
		{
			RegisterView( );
			Presenter = AppDelegate.Container.Resolve<T>( );
		}
	}
}

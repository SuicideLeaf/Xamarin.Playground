// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Features.Playground.iOS.Storyboards
{
	[Register ("MaintenanceDetailsCollectionViewCell")]
	partial class MaintenanceDetailsCollectionViewCell
	{
		[Outlet]
		UIKit.UIView ContainerView { get; set; }

		[Outlet]
		UIKit.UILabel ImageLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ImageLabel != null) {
				ImageLabel.Dispose ();
				ImageLabel = null;
			}

			if (ContainerView != null) {
				ContainerView.Dispose ();
				ContainerView = null;
			}
		}
	}
}

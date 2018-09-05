// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Features.Playground.iOS.ViewControllers.Maintenance.Details
{
	[Register ("MaintenanceDetailsViewController")]
	partial class MaintenanceDetailsViewController
	{
		[Outlet]
		Features.Playground.iOS.Views.Text.DescriptionLabel DescriptionDetailsLabel { get; set; }

		[Outlet]
		Features.Playground.iOS.Views.Text.DescriptionLabel DuplicateConstraintedDescriptionLabel { get; set; }

		[Outlet]
		UIKit.UICollectionView ImageCollectionView { get; set; }

		[Outlet]
		UIKit.NSLayoutConstraint ImageCollectionViewHeightConstraint { get; set; }

		[Outlet]
		Features.Playground.iOS.Views.Text.SmallLabel MoreLessDescriptionButton { get; set; }

		[Outlet]
		UIKit.NSLayoutConstraint MoreLessDescriptionHeightConstraint { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (MoreLessDescriptionHeightConstraint != null) {
				MoreLessDescriptionHeightConstraint.Dispose ();
				MoreLessDescriptionHeightConstraint = null;
			}

			if (DescriptionDetailsLabel != null) {
				DescriptionDetailsLabel.Dispose ();
				DescriptionDetailsLabel = null;
			}

			if (DuplicateConstraintedDescriptionLabel != null) {
				DuplicateConstraintedDescriptionLabel.Dispose ();
				DuplicateConstraintedDescriptionLabel = null;
			}

			if (ImageCollectionView != null) {
				ImageCollectionView.Dispose ();
				ImageCollectionView = null;
			}

			if (ImageCollectionViewHeightConstraint != null) {
				ImageCollectionViewHeightConstraint.Dispose ();
				ImageCollectionViewHeightConstraint = null;
			}

			if (MoreLessDescriptionButton != null) {
				MoreLessDescriptionButton.Dispose ();
				MoreLessDescriptionButton = null;
			}
		}
	}
}

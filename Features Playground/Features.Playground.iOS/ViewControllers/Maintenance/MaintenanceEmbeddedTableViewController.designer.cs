// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//

using Foundation;

namespace Features.Playground.iOS.ViewControllers.Maintenance
{
	[Register ("MaintenanceEmbeddedTableViewController")]
	partial class MaintenanceEmbeddedTableViewController
	{
		[Outlet]
		UIKit.UIImageView CompletedIcon { get; set; }

		[Outlet]
		UIKit.UITableViewCell CompletedTableViewCell { get; set; }

		[Outlet]
		UIKit.UIImageView CreateIcon { get; set; }

		[Outlet]
		UIKit.UILabel CreateLabel { get; set; }

		[Outlet]
		UIKit.UITableViewCell CreateMaintenanceTableViewCell { get; set; }

		[Outlet]
		UIKit.UIImageView IncompleteIcon { get; set; }

		[Outlet]
		UIKit.UITableViewCell IncompleteTableViewCell { get; set; }

		[Outlet]
		UIKit.UIImageView RequestedIcon { get; set; }

		[Outlet]
		UIKit.UITableViewCell RequestedTableViewCell { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (CompletedIcon != null) {
				CompletedIcon.Dispose ();
				CompletedIcon = null;
			}

			if (CompletedTableViewCell != null) {
				CompletedTableViewCell.Dispose ();
				CompletedTableViewCell = null;
			}

			if (CreateIcon != null) {
				CreateIcon.Dispose ();
				CreateIcon = null;
			}

			if (CreateLabel != null) {
				CreateLabel.Dispose ();
				CreateLabel = null;
			}

			if (CreateMaintenanceTableViewCell != null) {
				CreateMaintenanceTableViewCell.Dispose ();
				CreateMaintenanceTableViewCell = null;
			}

			if (IncompleteIcon != null) {
				IncompleteIcon.Dispose ();
				IncompleteIcon = null;
			}

			if (IncompleteTableViewCell != null) {
				IncompleteTableViewCell.Dispose ();
				IncompleteTableViewCell = null;
			}

			if (RequestedIcon != null) {
				RequestedIcon.Dispose ();
				RequestedIcon = null;
			}

			if (RequestedTableViewCell != null) {
				RequestedTableViewCell.Dispose ();
				RequestedTableViewCell = null;
			}
		}
	}
}

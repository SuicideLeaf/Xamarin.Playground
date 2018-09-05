// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//

using Foundation;

namespace Features.Playground.iOS.ViewControllers.Maintenance.List
{
	[Register ("MaintenanceListViewController2")]
	partial class MaintenanceListViewController2
	{
		[Outlet]
		UIKit.UITableView MaintenanceTableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (MaintenanceTableView != null) {
				MaintenanceTableView.Dispose ();
				MaintenanceTableView = null;
			}
		}
	}
}

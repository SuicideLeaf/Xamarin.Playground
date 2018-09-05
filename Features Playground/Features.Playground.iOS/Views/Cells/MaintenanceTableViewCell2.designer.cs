// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//

using Foundation;

namespace Features.Playground.iOS.Views.Cells
{
	[Register ("MaintenanceTableViewCell2")]
	partial class MaintenanceTableViewCell2
	{
		[Outlet]
		Features.Playground.iOS.Views.Text.SecondaryCellLabel DueDateLabel { get; set; }

		[Outlet]
		Features.Playground.iOS.Views.Text.PrimaryCellLabel TitleLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (TitleLabel != null) {
				TitleLabel.Dispose ();
				TitleLabel = null;
			}

			if (DueDateLabel != null) {
				DueDateLabel.Dispose ();
				DueDateLabel = null;
			}
		}
	}
}

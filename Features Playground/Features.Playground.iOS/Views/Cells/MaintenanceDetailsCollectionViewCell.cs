// This file has been autogenerated from a class added in the UI designer.

using System;
using UIKit;

namespace Features.Playground.iOS.Views.Cells
{
	public partial class MaintenanceDetailsCollectionViewCell : UICollectionViewCell
	{
		public MaintenanceDetailsCollectionViewCell( IntPtr handle ) : base( handle )
		{
		}

		public const string Identifier = "MaintenanceDetailsCollectionViewCell";

		public override void AwakeFromNib( )
		{
			base.AwakeFromNib( );

			ContainerView.BackgroundColor = UIColor.Gray;
			ContainerView.Layer.CornerRadius = 10.0f;
		}

		public void UpdateViews( string label )
		{
			ImageLabel.Text = label;
		}
	}
}
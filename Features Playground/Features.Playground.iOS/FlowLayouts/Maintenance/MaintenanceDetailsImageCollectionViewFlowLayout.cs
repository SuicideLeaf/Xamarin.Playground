using UIKit;

namespace Features.Playground.iOS.FlowLayouts.Maintenance
{
	public class MaintenanceDetailsImageCollectionViewFlowLayout : UICollectionViewFlowLayout
	{
		public override void PrepareLayout( )
		{
			base.PrepareLayout( );

			ScrollDirection = UICollectionViewScrollDirection.Horizontal;
		}
	}
}
using System;
using Features.Playground.iOS.Storyboards;
using Foundation;
using UIKit;

namespace Features.Playground.iOS.Sources.Maintenance
{
	public class MaintenanceDetailsImageCollectionViewDataSource : UICollectionViewDataSource
	{
		public override nint GetItemsCount( UICollectionView collectionView, nint section )
		{
			return 20;
		}

		public override UICollectionViewCell GetCell( UICollectionView collectionView, NSIndexPath indexPath )
		{
			MaintenanceDetailsCollectionViewCell cell = ( MaintenanceDetailsCollectionViewCell ) collectionView.DequeueReusableCell( MaintenanceDetailsCollectionViewCell.Identifier, indexPath );
			
			cell.UpdateViews( indexPath.Row.ToString( ) );

			return cell;
		}
	}
}
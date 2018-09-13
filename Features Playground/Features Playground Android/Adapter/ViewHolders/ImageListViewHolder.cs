using Android.Graphics;
using Android.Views;
using Android.Widget;
using static Android.Support.V7.Widget.RecyclerView;

namespace Features_Playground_Android.Adapter.ViewHolders
{
	public class ImageListViewHolder : ViewHolder
	{
		private readonly ImageView _imageView;

		public ImageListViewHolder( View itemView ) : base( itemView )
		{
			_imageView = itemView.FindViewById<ImageView>( Resource.Id.maintenance_listitem_imageView );
		}
	}
}
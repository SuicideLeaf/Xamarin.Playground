using Android.Support.V7.Widget;
using Android.Views;
using Features_Playground_Android.Adapter.ViewHolders;

namespace Features_Playground_Android.Adapter
{
	public class ImagesAdapter : RecyclerView.Adapter
	{
		public override int ItemCount => 20;

		public override void OnBindViewHolder( RecyclerView.ViewHolder holder, int position )
		{
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder( ViewGroup parent, int viewType )
		{
			View view = LayoutInflater.From( parent.Context ).Inflate( Resource.Layout.layout_image_listitem, parent, false );
			return new ImageListViewHolder( view );
		}
	}
}
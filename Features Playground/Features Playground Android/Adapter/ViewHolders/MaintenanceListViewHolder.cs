using Android.Graphics;
using Android.Support.Constraints;
using Android.Views;
using Android.Widget;
using Features.Playground.Core.Models;
using System;
using static Android.Support.V7.Widget.RecyclerView;

namespace Features_Playground_Android.Adapter.ViewHolders
{
	public class MaintenanceListViewHolder : ViewHolder
	{
		private readonly TextView _title;
		private readonly TextView _dueDate;
		private static Color Red = Color.ParseColor( "#ce4837" );
		private ConstraintLayout _maintenanceListItemConstraintLayout;
		public MaintenanceListViewHolder( View itemView, Action<object, int>clickAction) : base( itemView )
		{
			_title = itemView.FindViewById<TextView>( Resource.Id.maintenancelistitem_title );
			_dueDate = itemView.FindViewById<TextView>( Resource.Id.maintenancelistitem_dueDate );
			_maintenanceListItemConstraintLayout = itemView.FindViewById<ConstraintLayout>( Resource.Id.maintenancelistitem_ConstraintLayout );
			_maintenanceListItemConstraintLayout.Click += ( s, e ) => clickAction( this, AdapterPosition );
		}

		public void UpdateViews( MaintenanceListItem maintenanceListItem )
		{
			if ( maintenanceListItem.IsOverDue )
			{
				_title.SetTextColor( Red );
				_dueDate.SetTextColor( Red );
			}
			else
			{
				_title.SetTextColor( Color.DarkGray );
				_dueDate.SetTextColor( Color.Gray );
			}

			_title.Text = maintenanceListItem.Title;
			_dueDate.Text = maintenanceListItem.DueDate.ToString( "dd MMMMM yyyy" );
		}
	}
}
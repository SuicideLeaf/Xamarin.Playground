using System;
using System.Collections.Generic;
using System.Linq;
using Android.Support.V7.Widget;
using Android.Views;
using Features.Playground.Core.Classes;
using Features.Playground.Core.Models;
using Features_Playground_Android.Adapter.ViewHolders;

namespace Features_Playground_Android.Adapter
{
	public class MaintenanceListAdapter : RecyclerView.Adapter
	{
		public List<MaintenanceListItem> Items { get; set; }
		public EventHandler<int> ItemClicked { get; set; }
		public MaintenanceListAdapter( Enums.MaintenanceStatus maintenanceStatus )
		{
			Items = new List<MaintenanceListItem>( );

			Random rnd = new Random( );
			var itemCount = rnd.Next( 0, 20 );
			for ( int i = 0; i < itemCount; i++ )
			{
				var month = rnd.Next( 7, 10 );
				var day = rnd.Next( 1, 30 );

				MaintenanceListItem item = new MaintenanceListItem
				{
					Status = maintenanceStatus,
					Title = $"Maintenance {i}",
					DueDate = new DateTime( 2018, month, day )
				};

				Items.Add( item );
			}

			Items = Items.OrderBy( m => m.DueDate ).ThenBy( m => m.Title ).ToList( );
		}

		public override int ItemCount => Items.Count;

		public override void OnBindViewHolder( RecyclerView.ViewHolder holder, int position )
		{
			if ( holder is MaintenanceListViewHolder maintenanceListViewHolder )
			{
				maintenanceListViewHolder.UpdateViews( Items[ position ] );
			}
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder( ViewGroup parent, int viewType )
		{
			View view = LayoutInflater.From( parent.Context ).Inflate( Resource.Layout.layout_maintenancelistitem, parent, false );
			return new MaintenanceListViewHolder( view, OnClick );
		}

		private Action<object, int> OnClick => ( obj, pos ) =>
	  {
		  ItemClicked?.Invoke( obj, pos );
	  };
	}
}
using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Features_Playground_Android.Adapter;
using Features.Playground.Core.Classes;

namespace Features_Playground_Android.Activities
{
	[Activity( Label = "Maintenance List" )]
	public class MaintenanceListActivity : ToolbarBackActivity
	{
		private Enums.MaintenanceStatus _maintenanceStatus;

		private RecyclerView _recyclerView;
		private SwipeRefreshLayout _swipeRefreshLayout;

		protected override void OnCreate( Bundle savedInstanceState )
		{
			base.OnCreate( savedInstanceState );
			SetContentView( Resource.Layout.activity_maintenancelist );
			_maintenanceStatus = ( Enums.MaintenanceStatus )Intent.GetIntExtra( "Status", -1 );

			SetNavigationTitle( );
			FindViews( );
			SetupViews( );
		}

		private void FindViews( )
		{
			_recyclerView = FindViewById<RecyclerView>( Resource.Id.maintenancelist_recyclerView );
			_swipeRefreshLayout = FindViewById<SwipeRefreshLayout>( Resource.Id.maintenancelist_swipeRefresh );
			_swipeRefreshLayout.Refresh += _swipeRefreshLayout_Refresh;

		}

		private void _swipeRefreshLayout_Refresh( object sender, EventArgs e )
		{
			_swipeRefreshLayout.Refreshing = false;
		}

		private void SetupViews( )
		{
			LinearLayoutManager layoutManager = new LinearLayoutManager( this );
			DividerItemDecoration dividerItemDecoration = new DividerItemDecoration( this, layoutManager.Orientation );

			_recyclerView.SetLayoutManager( layoutManager );
			_recyclerView.AddItemDecoration( dividerItemDecoration );

			MaintenanceListAdapter adapter = new MaintenanceListAdapter( _maintenanceStatus );
			adapter.ItemClicked += ( s, e ) => Adapter_ItemClicked( e, adapter );
			_recyclerView.SetAdapter( adapter );
		}

		private void Adapter_ItemClicked( int pos, MaintenanceListAdapter adapter )
		{
			Intent intent = new Intent( this, typeof( MaintenanceDetailsActivity ) );
			StartActivity( intent );
		}

		private void SetNavigationTitle( )
		{
			string navigationBarTitle = "{0} Maintenance";

			switch ( _maintenanceStatus )
			{
				case Enums.MaintenanceStatus.Incomplete:
					navigationBarTitle = string.Format( navigationBarTitle, "Incomplete" );
					break;
				case Enums.MaintenanceStatus.Complete:
					navigationBarTitle = string.Format( navigationBarTitle, "Completed" );
					break;
				case Enums.MaintenanceStatus.Requested:
					navigationBarTitle = string.Format( navigationBarTitle, "Requested" );
					break;
				default:
					navigationBarTitle = "Maintenance";
					break;
			}

			SupportActionBar.Title = navigationBarTitle.ToString( );
		}
	}
}
using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Views;
using Features.Playground.Core.Classes;
using Features_Playground_Android.Activities;
using Android.Support.V7.Widget;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Support.V4.View;

namespace Features_Playground_Android
{
	[Activity( Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true )]
	public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
	{
		private CardView _completedCardView;
		private CardView _requestedCardView;
		private CardView _incompleteCardView;
		private CardView _createMaintenanceCardView;

		protected override void OnCreate( Bundle savedInstanceState )
		{
			base.OnCreate( savedInstanceState );
			SetContentView( Resource.Layout.activity_main );
			Toolbar toolbar = FindViewById<Toolbar>( Resource.Id.toolbar );
			SetSupportActionBar( toolbar );

			FloatingActionButton fab = FindViewById<FloatingActionButton>( Resource.Id.fab );
			fab.Click += FabOnClick;

			DrawerLayout drawer = FindViewById<DrawerLayout>( Resource.Id.drawer_layout );
			ActionBarDrawerToggle toggle = new ActionBarDrawerToggle( this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close );
			drawer.AddDrawerListener( toggle );
			toggle.SyncState( );

			NavigationView navigationView = FindViewById<NavigationView>( Resource.Id.nav_view );
			navigationView.SetNavigationItemSelectedListener( this );

			FindViews( );
			SetupViews( );
		}

		private void FindViews( )
		{
			_completedCardView = FindViewById<CardView>( Resource.Id.cardview_completed );
			_incompleteCardView = FindViewById<CardView>( Resource.Id.cardview_incomplete );
			_requestedCardView = FindViewById<CardView>( Resource.Id.cardview_requested );
			_createMaintenanceCardView = FindViewById<CardView>( Resource.Id.cardview_create );
		}

		private void SetupViews( )
		{
			_completedCardView.Click += ( s, e ) => OnClick_CardView( Enums.MaintenanceStatus.Complete );
			_incompleteCardView.Click += ( s, e ) => OnClick_CardView( Enums.MaintenanceStatus.Incomplete );
			_requestedCardView.Click += ( s, e ) => OnClick_CardView( Enums.MaintenanceStatus.Requested );
			_createMaintenanceCardView.Click += FabOnClick;
		}

		private void OnClick_CardView( Enums.MaintenanceStatus status )
		{
			Intent intent = new Intent( this, typeof( MaintenanceListActivity ) );
			intent.PutExtra( "Status", ( int )status );
			StartActivity( intent );
		}

		public override void OnBackPressed( )
		{
			DrawerLayout drawer = FindViewById<DrawerLayout>( Resource.Id.drawer_layout );
			if ( drawer.IsDrawerOpen( GravityCompat.Start ) )
			{
				drawer.CloseDrawer( GravityCompat.Start );
			}
			else
			{
				base.OnBackPressed( );
			}
		}

		public override bool OnCreateOptionsMenu( IMenu menu )
		{
			MenuInflater.Inflate( Resource.Menu.menu_main, menu );
			return true;
		}

		public override bool OnOptionsItemSelected( IMenuItem item )
		{
			int id = item.ItemId;
			if ( id == Resource.Id.action_settings )
			{
				return true;
			}

			return base.OnOptionsItemSelected( item );
		}

		private void FabOnClick( object sender, EventArgs eventArgs )
		{
			View view = ( View )sender;
			Snackbar.Make( view, "Create maintenance", Snackbar.LengthLong )
				 .SetAction( "Action", ( View.IOnClickListener )null ).Show( );
		}

		public bool OnNavigationItemSelected( IMenuItem item )
		{
			int id = item.ItemId;

			if ( id == Resource.Id.nav_camera )
			{
				// Handle the camera action
			}
			else if ( id == Resource.Id.nav_gallery )
			{

			}
			else if ( id == Resource.Id.nav_slideshow )
			{

			}
			else if ( id == Resource.Id.nav_manage )
			{

			}
			else if ( id == Resource.Id.nav_share )
			{

			}
			else if ( id == Resource.Id.nav_send )
			{

			}

			DrawerLayout drawer = FindViewById<DrawerLayout>( Resource.Id.drawer_layout );
			drawer.CloseDrawer( GravityCompat.Start );
			return true;
		}
	}
}


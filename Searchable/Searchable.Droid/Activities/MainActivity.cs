using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;

namespace Searchable.Droid.Activities
{
	[Activity( Label = "Main", MainLauncher = true )]
	//[MetaData( "android.app.searchable", Resource = "@xml/searchable" )]
	public class MainActivity : Activity
	{
		protected override void OnCreate( Bundle savedInstanceState )
		{
			base.OnCreate( savedInstanceState );

			// Set our view from the "main" layout resource
			SetContentView( Resource.Layout.activity_main );
		}

//		public override bool OnCreateOptionsMenu( IMenu menu )
//		{
//			MenuInflater.Inflate( Resource.Menu.menu_search, menu );
//
//			SearchManager searchManager = ( SearchManager ) GetSystemService( SearchService );
//			SearchView searchView = ( SearchView ) menu.FindItem( Resource.Id.menu_search ).ActionView;
//
////			searchView.SetSearchableInfo( searchManager.GetSearchableInfo( ComponentName ) );
////			searchView.SetIconifiedByDefault( false ); // Do not iconify the widget; expand it by default
//
//			return true;
//		}
	}
}
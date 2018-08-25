using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;

namespace Searchable.Droid.Activities
{
	[Activity( Label = "Main", MainLauncher = true )]
	[MetaData( "android.app.default_searchable", Value = "com.released.Searchable.SearchableActivity" )]
	public class MainActivity : AppCompatActivity
	{
		protected override void OnCreate( Bundle savedInstanceState )
		{
			base.OnCreate( savedInstanceState );

			// Set our view from the "main" layout resource
			SetContentView( Resource.Layout.activity_main );
		}

		public override bool OnCreateOptionsMenu( IMenu menu )
		{
			MenuInflater.Inflate( Resource.Menu.menu_search, menu );

			SearchManager searchManager = ( SearchManager )GetSystemService( SearchService );
			SearchView searchView = ( SearchView )menu.FindItem( Resource.Id.menu_search ).ActionView;

			searchView.SetSearchableInfo( searchManager.GetSearchableInfo( ComponentName ) );
			
			return true;
		}
	}
}
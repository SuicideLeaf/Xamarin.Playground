using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;

namespace Searchable.Droid.Activities
{
	[Register( "com.released.Searchable.SearchableActivity" )]
	[Activity( Label = "Searchable Activity", LaunchMode = LaunchMode.SingleTop, Theme = "@style/Theme.AppCompat.Light" )]
	[IntentFilter( new[ ] { Intent.ActionSearch } )]
	[MetaData( "android.app.searchable", Resource = "@xml/searchable", Value = "com.released.Searchable.SearchableActivity" )]
	public class SearchableActivity : AppCompatActivity
	{
		private string _query;

		protected override async void OnCreate( Bundle savedInstanceState )
		{
			base.OnCreate( savedInstanceState );

			SetContentView( Resource.Layout.activity_search );
			SupportActionBar.SetDisplayHomeAsUpEnabled( true );
			SupportActionBar.SetDisplayShowHomeEnabled( true );

			await HandleSearch( );
		}

		protected override async void OnNewIntent( Intent intent )
		{
			await HandleSearch( );
		}

		private async Task HandleSearch( )
		{
			if ( Intent.ActionSearch.Equals( Intent.Action ) )
			{
				_query = Intent.GetStringExtra( SearchManager.Query );
				await DoSearch( _query );
			}
		}

		private async Task DoSearch( string query )
		{
			//throw new System.NotImplementedException( );
		}

		public override bool OnCreateOptionsMenu( IMenu menu )
		{
			MenuInflater.Inflate( Resource.Menu.menu_search_2, menu );

			SearchManager searchManager = ( SearchManager )GetSystemService( SearchService );
			SearchView searchView = ( SearchView )menu.FindItem( Resource.Id.menu_search ).ActionView;
			searchView.SetSearchableInfo( searchManager.GetSearchableInfo( ComponentName ) );
			searchView.OnActionViewExpanded( );

			if ( _query != null )
			{
				searchView.SetQuery( _query, false );
			}

			return true;
		}

		public override bool OnOptionsItemSelected( IMenuItem item )
		{
			if ( item.ItemId == Android.Resource.Id.Home )
			{
				Finish( );

				return true;
			}

			return base.OnOptionsItemSelected( item );
		}
	}
}
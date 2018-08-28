
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
	[Activity( Label = "BlockPageActivity", Theme = "@style/Transparent" )]
	[MetaData( "android.app.default_searchable", Value = "com.released.Searchable.SearchableActivity" )]
	public class BlockPageActivity : AppCompatActivity
	{
		public override bool OnCreateOptionsMenu( IMenu menu )
		{
			MenuInflater.Inflate( Resource.Menu.menu_search_2, menu );

			SearchManager searchManager = ( SearchManager )GetSystemService( SearchService );
			SearchView searchView = ( SearchView )menu.FindItem( Resource.Id.menu_search ).ActionView;
			searchView.SetSearchableInfo( searchManager.GetSearchableInfo( ComponentName ) );
			searchView.OnActionViewExpanded( );
			return true;
		}

		protected override void OnCreate( Bundle savedInstanceState )
		{
			base.OnCreate( savedInstanceState );

			SetContentView( Resource.Layout.activity_search );
			SupportActionBar.SetDisplayHomeAsUpEnabled( true );
			SupportActionBar.SetDisplayShowHomeEnabled( true );

			// Create your application here
		}

		public override bool OnOptionsItemSelected( IMenuItem item )
		{
			if ( item.ItemId == Android.Resource.Id.Home )
			{
				FinishAfterTransition( );
				return true;
			}

			return base.OnOptionsItemSelected( item );
		}
	}

}

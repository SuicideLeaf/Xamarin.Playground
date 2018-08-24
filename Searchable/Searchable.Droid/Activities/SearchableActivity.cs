using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;

namespace Searchable.Droid.Activities
{
	[IntentFilter( new[ ] {Intent.ActionSearch} )]
	[Activity( Label = "Searchable Activity" )]
	public class SearchableActivity : Activity
	{
		protected override async void OnCreate( Bundle savedInstanceState )
		{
			base.OnCreate( savedInstanceState );
			
			SetContentView( Resource.Layout.activity_search );

			if ( Intent.ActionSearch.Equals( Intent.Action ) )
			{
				string query = Intent.GetStringExtra( SearchManager.Query );
				await DoSearch( query );
			}
		}

		private async Task DoSearch( string query )
		{
			//throw new System.NotImplementedException( );
		}
	}
}
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;

namespace Searchable.Droid.Activities
{
	[Activity( Label = "Main", MainLauncher = true )]
	public class MainActivity : AppCompatActivity
	{
		protected override void OnCreate( Bundle savedInstanceState )
		{
			base.OnCreate( savedInstanceState );
			SetContentView( Resource.Layout.activity_main );
		}

		public override bool OnOptionsItemSelected( IMenuItem item )
		{
			if ( item.ItemId == Resource.Id.menu_search )
			{
				Intent intent = new Intent( this, typeof( BlockPageActivity ) );
				intent.SetFlags( ActivityFlags.NoHistory );
				StartActivity( intent, ActivityOptions.MakeSceneTransitionAnimation( this ).ToBundle( ) );
				return true;
			}

			return base.OnOptionsItemSelected( item );
		}

		public override bool OnCreateOptionsMenu( IMenu menu )
		{
			MenuInflater.Inflate( Resource.Menu.menu_search, menu );
			return true;
		}
	}
}
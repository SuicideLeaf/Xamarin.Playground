using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;

namespace BluetoothLE.Droid
{
	[Activity( Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true )]
	public class MainActivity : AppCompatActivity
	{
		private Toolbar _toolbar;

		protected override void OnCreate( Bundle savedInstanceState )
		{
			base.OnCreate( savedInstanceState );

			SetContentView( Resource.Layout.activity_main );

			FindViews( );

			SetupViews( );
		}

		public void FindViews( )
		{
			_toolbar = FindViewById<Toolbar>( Resource.Id.toolbar );
		}

		private void SetupViews( )
		{
			SetSupportActionBar( _toolbar );
		}
	}
}


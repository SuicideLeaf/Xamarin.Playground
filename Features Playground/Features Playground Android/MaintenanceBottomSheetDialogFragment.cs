using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using Features_Playground_Android.Callback;

namespace Features_Playground_Android
{
	public class MaintenanceBottomSheetDialogFragment : BottomSheetDialogFragment
	{
		private BottomSheetCallbackEvent mBottomSheetBehaviorCallback;
		private TextView _fullDescriptionTextView;
		private readonly string _fullDescription;

		public MaintenanceBottomSheetDialogFragment( string fullDescription )
		{
			_fullDescription = fullDescription;
		}

		public override void OnCreate( Bundle savedInstanceState )
		{
			base.OnCreate( savedInstanceState );
			mBottomSheetBehaviorCallback = new BottomSheetCallbackEvent( this );
		}

		public override void SetupDialog( Dialog dialog, int style )
		{
			base.SetupDialog( dialog, style );
			View contentView = View.Inflate( Context, Resource.Layout.maintenance_description_dialog_modal, null );
			_fullDescriptionTextView = contentView.FindViewById<TextView>( Resource.Id.full_description_textView );
			_fullDescriptionTextView.Text = _fullDescription;
			dialog.SetContentView( contentView );

			CoordinatorLayout.LayoutParams layoutParams =
					  ( CoordinatorLayout.LayoutParams )( ( View )contentView.Parent ).LayoutParameters;
			CoordinatorLayout.Behavior behavior = layoutParams.Behavior;
			if ( behavior != null && behavior is BottomSheetBehavior )
			{
				( ( BottomSheetBehavior )behavior ).SetBottomSheetCallback( mBottomSheetBehaviorCallback );
			}
		}

	}
}
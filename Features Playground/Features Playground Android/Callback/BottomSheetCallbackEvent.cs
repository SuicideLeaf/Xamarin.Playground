using Android.Support.Design.Widget;
using Android.Views;

namespace Features_Playground_Android.Callback
{
	public class BottomSheetCallbackEvent : BottomSheetBehavior.BottomSheetCallback
	{
		MaintenanceBottomSheetDialogFragment _maintenanceBottomSheetDialogFragment;

		public BottomSheetCallbackEvent( MaintenanceBottomSheetDialogFragment maintenanceBottomSheetDialogFragment ) : base( )
		{
			_maintenanceBottomSheetDialogFragment = maintenanceBottomSheetDialogFragment;
		}

		public override void OnSlide( View bottomSheet, float slideOffset )
		{

		}

		public override void OnStateChanged( View bottomSheet, int newState )
		{
			if ( newState == BottomSheetBehavior.StateHidden )
			{
				_maintenanceBottomSheetDialogFragment.Dismiss( );
			}
		}
	}
}
using System;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Text;
using Android.Views;
using Android.Widget;
using Features_Playground_Android.Adapter;
using static Android.Views.ViewTreeObserver;

namespace Features_Playground_Android.Activities
{
	[Activity( Label = "Maintenance Details" )]
	public class MaintenanceDetailsActivity : ToolbarBackActivity
	{
		public Button ShowDescriptionButton { get; set; }
		public TextView DescriptionTextView { get; set; }
		private RecyclerView _recyclerView;
		private TextView _titleTextView;
		private TextView _statusTextView;
		private TextView _typeTextView;
		private TextView _dueDateTextView;
		private TextView _contractorNameTextView;

		protected override void OnCreate( Bundle savedInstanceState )
		{
			base.OnCreate( savedInstanceState );
			SetContentView( Resource.Layout.activity_maintenance_details );
			FindViewsWith( );
			SetupViews( );
			SetupMockData( );
		}

		private void FindViewsWith( )
		{

			ShowDescriptionButton = FindViewById<Button>( Resource.Id.description_showhide_Button );
			DescriptionTextView = FindViewById<TextView>( Resource.Id.description_textView );
			_titleTextView = FindViewById<TextView>( Resource.Id.title_textView );
			_statusTextView = FindViewById<TextView>( Resource.Id.status_textView );
			_typeTextView = FindViewById<TextView>( Resource.Id.type_textView );
			_dueDateTextView = FindViewById<TextView>( Resource.Id.duedate_textView );
			_contractorNameTextView = FindViewById<TextView>( Resource.Id.contractor_textView );
			_recyclerView = FindViewById<RecyclerView>( Resource.Id.images_recyclerView );
		}

		private void SetupViews( )
		{
			ShowDescriptionButton.Click += ( s, e ) => ShowDescriptionButton_Click( );
			ShowDescriptionButton.Text = "Show full description";
			LinearLayoutManager layoutManager = new LinearLayoutManager( this, ( int )Orientation.Horizontal, false );
			_recyclerView.SetLayoutManager( layoutManager );
			ImagesAdapter adapter = new ImagesAdapter( );
			_recyclerView.SetAdapter( adapter );
			 DescriptionTextView.ViewTreeObserver.AddOnGlobalLayoutListener( new TextViewOnGlobalLayoutListener( this ) );
		}

		private void ShowDescriptionButton_Click( )
		{
			BottomSheetDialogFragment bottomSheetDialogFragment = new MaintenanceBottomSheetDialogFragment( DescriptionTextView.Text );
			//show it
			bottomSheetDialogFragment.Show( SupportFragmentManager, bottomSheetDialogFragment.Tag );
		}

		private void SetupMockData( )
		{
			_titleTextView.Text = "Broken Glass Window In Lounge - Right Side";
			DescriptionTextView.Text = "This is a description for the broken glass. Broken glass is on the right side of the lounge, facing the road. " +
			"Ball was thrown through window, whole window will need replacement. Blah blah blah Blah blah blah Blah bla" +
			"h blah Blah blah blah Blah blah blah Blah blah blah Blah blah blah Blah blah blah Blah blah blah Blah blah blah Blah blah blah  " +
			"Blah blah blah Blah blah blah Blah blah blah Blah blah blah Blah blah blah Blah blah blah Blah blah blah Blah blah blah Blah blah blah Blah blah blah Blah blah blah";

			_statusTextView.Text = "Requested";
			_dueDateTextView.Text = "1 September 2018";
			_typeTextView.Text = "Tile";
			_contractorNameTextView.Text = "Lee Matulich";
		}
	
	}

	public class TextViewOnGlobalLayoutListener : Java.Lang.Object, IOnGlobalLayoutListener
	{

		MaintenanceDetailsActivity _maintenanceDetailsActivity;

		public TextViewOnGlobalLayoutListener( MaintenanceDetailsActivity maintenanceDetailsActivity )
		{
			_maintenanceDetailsActivity = maintenanceDetailsActivity;
		}

		public void OnGlobalLayout( )
		{
			_maintenanceDetailsActivity.ShowDescriptionButton.Visibility = IsTextTruncated( _maintenanceDetailsActivity.DescriptionTextView.Text, _maintenanceDetailsActivity.DescriptionTextView ) ? ViewStates.Visible : ViewStates.Gone;
		}

		public static bool IsTextTruncated( String text, TextView textView )
		{
			if ( textView != null && text != null )
			{
				Layout layout = textView.Layout;
				if ( layout != null )
				{
					int lines = layout.LineCount;
					if ( lines > 0 )
					{
						int ellipsisCount = layout.GetEllipsisCount( lines - 1 );
						if ( ellipsisCount > 0 )
						{
							return true;
						}
					}
				}
			}
			return false;
		}
	}
}
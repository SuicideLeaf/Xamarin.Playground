using System;
using Android.App;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using MvpArchitecture.Android.Classes;
using MvpArchitecture.Android.Helpers;
using MvpArchitecture.Areas.Contacts;
using MvpArchitecture.Data.Models.Contacts;
using Unity;
using static MvpArchitecture.Areas.Contacts.ContactsContract;

namespace MvpArchitecture.Android.Areas.Contacts
{
	[Activity( Label = "Contacts", MainLauncher = true )]
	public class ContactsActivity : BaseUnityActivity<ContactsPresenter>, IContactsView
	{
		private ContactsAdapter _contactsAdapter;
		private RecyclerView _recyclerView;
		private LinearLayout _contactsView;
		private LinearLayout _noContactsView;
		private TextView _noContactsTextView;
		private SwipeRefreshLayout _swipeRefreshLayout;

		public int LeaseId { get; set; }

		public override void RegisterView( )
		{
			App.Container.RegisterInstance<IContactsView>( this );
		}

		protected override void OnCreate( Bundle savedInstanceState )
		{
			base.OnCreate( savedInstanceState );

			SetContentView( Resource.Layout.contacts_activity );

			LeaseId = 10052;
			PreferencesHelper.SetInstanceUrl( this, "http://192.168.108.219:57204/" );
			PreferencesHelper.SetAuthenticationToken( this, new Guid( "476F624F-2238-4041-AC31-C78F4E1DE869" ) );

			FindViews( );

			SetupViews( );
		}

		protected override void OnResume( )
		{
			base.OnResume( );
			Presenter.Start( );
		}

		private void FindViews( )
		{
			_recyclerView = FindViewById<RecyclerView>( Resource.Id.contacts_recyclerview );
			_contactsView = FindViewById<LinearLayout>( Resource.Id.contacts_exist_rootlayout );
			_noContactsView = FindViewById<LinearLayout>( Resource.Id.contacts_none_rootlayout );
			_noContactsTextView = FindViewById<TextView>( Resource.Id.contacts_none_textview );
			_swipeRefreshLayout = FindViewById<SwipeRefreshLayout>( Resource.Id.refresh_layout );
		}

		private void SetupViews( )
		{
			_contactsAdapter = new ContactsAdapter( new ContactListViewModel( ) );
			_recyclerView.SetLayoutManager( new LinearLayoutManager( this ) );
			_recyclerView.SetAdapter( _contactsAdapter );

			_swipeRefreshLayout.Refresh += ( sender, e ) =>
			{
				Presenter.LoadContacts( true );
			};

			SetPresenter( );
		}

		public bool IsActive => true;

		public void ShowContacts( ContactListViewModel contactList )
		{
			_contactsAdapter.ReplaceData( contactList );
			ToggleRefreshing( false );
			ToggleRetryOverlay( false );
			ToggleLoadingOverlay( false );
		}

		public void ToggleRefreshing( bool active )
		{
			_swipeRefreshLayout.Refreshing = active;
		}

		public void ToggleLoadingOverlay( bool active )
		{
			_contactsView.Visibility = active ? ViewStates.Gone : ViewStates.Visible;
			_noContactsView.Visibility = active ? ViewStates.Visible : ViewStates.Gone;
			_noContactsTextView.Text = "Loading...";
		}

		public void ToggleRetryOverlay( bool active, string message = "" )
		{
			_contactsView.Visibility = active ? ViewStates.Gone : ViewStates.Visible;
			_noContactsView.Visibility = active ? ViewStates.Visible : ViewStates.Gone;
			_noContactsTextView.Text = message;
		}

		public void ShowNoContacts( )
		{
			ToggleRefreshing( false );
			ToggleLoadingOverlay( false );
			ToggleRetryOverlay( true, "No contacts found... Tap to retry" );
		}

		public void ShowLoadingContactsError( )
		{
			ToggleRefreshing( false );
			ToggleLoadingOverlay( false );
			ToggleRetryOverlay( true, "Something went wrong... Tap to retry" );
		}
	}
}

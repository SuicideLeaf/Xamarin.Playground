using System.Linq;
using MvpArchitecture.Data.Models.Contacts;
using static MvpArchitecture.Areas.Contacts.ContactsContract;
using static MvpArchitecture.Areas.Contacts.ContactsContract.Data;

namespace MvpArchitecture.Areas.Contacts
{
	public class ContactsViewCallback : IGetContactsCallback
	{
		private readonly IContactsView _contactsView;

		public ContactsViewCallback( IContactsView contactsView )
		{
			_contactsView = contactsView;
		}

		public void OnContactsLoaded( ContactListViewModel contactList )
		{
			_contactsView.RunOnUiThread( ( ) =>
			{
				// The view may not be able to handle UI updates anymore
				if ( !_contactsView.IsActive )
				{
					return;
				}

				ProcessContacts( contactList );
			} );
		}

		public void OnDataNotAvailable( )
		{
			_contactsView.RunOnUiThread( ( ) =>
			{
				// The view may not be able to handle UI updates anymore
				if ( !_contactsView.IsActive )
				{
					return;
				}

				_contactsView.ShowLoadingContactsError( );
			} );
		}

		private void ProcessContacts( ContactListViewModel contactList )
		{
			if ( contactList != null && contactList.Contacts.Any( ) )
			{
				// Show the list of tasks
				_contactsView.ShowContacts( contactList );
			}
			else
			{
				// Show a message indicating there are no contacts.
				_contactsView.ShowNoContacts( );
			}
		}
	}
}

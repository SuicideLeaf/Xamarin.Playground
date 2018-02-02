using static MvpArchitecture.Areas.Contacts.ContactsContract;
using static MvpArchitecture.Areas.Contacts.ContactsContract.Data;

namespace MvpArchitecture.Areas.Contacts
{
	public class ContactsPresenter : BasePresenter<IContactsView>, IContactsPresenter
	{
		private IContactsDataSource _contactsRepository;
		private IGetContactsCallback _contactsViewCallback;

		public ContactsPresenter( IContactsDataSource contactsRepository, IContactsView contactsView, IGetContactsCallback contactsViewCallback )
			: base( contactsView )
		{
			_contactsRepository = contactsRepository;
			_contactsViewCallback = contactsViewCallback;
		}

		public void LoadContacts( )
		{
			LoadContacts( false );
		}

		public void LoadContacts( bool isRefreshing )
		{
			if ( isRefreshing )
			{
				View.ToggleRefreshing( true );
			}
			else
			{
				View.ToggleLoadingOverlay( true );
			}

			_contactsRepository.GetContacts( _contactsViewCallback, new[ ] { $"leaseId={View.LeaseId}" } );
		}

		public void LoadContactDetails( )
		{
			throw new System.NotImplementedException( );
		}

		public override void Start( )
		{
			LoadContacts( );
		}
	}
}

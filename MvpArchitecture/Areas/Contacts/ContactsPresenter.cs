using System.Threading.Tasks;
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

		public async Task LoadContacts( )
		{
			await LoadContacts( false );
		}

		public async Task LoadContacts( bool isRefreshing )
		{
			if ( !isRefreshing )
			{
				View.ShowLoadingOverlay( );
			}

			await _contactsRepository.GetContacts( _contactsViewCallback, View.QueryParameters );
		}

		public async Task LoadContactDetails( )
		{
			throw new System.NotImplementedException( );
		}

		public override async Task Start( )
		{
			await LoadContacts( );
		}
	}
}

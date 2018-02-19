using System.Threading.Tasks;
using static MvpArchitecture.Areas.Contacts.ContactsContract.Data;

namespace MvpArchitecture.Areas.Contacts
{
	public class ContactsRepository : IContactsDataSource
	{
		private readonly IContactsDataSource _contactsApiDataSource;

		public ContactsRepository( IContactsDataSource contactsApiDataSource )
		{
			_contactsApiDataSource = contactsApiDataSource;
		}

		public async Task GetContact( IGetContactCallBack callback, string[ ] extraParams )
		{
			await _contactsApiDataSource.GetContact( callback, extraParams );
		}

		public async Task GetContacts( IGetContactsCallback callback, ContactsQueryParameters queryParams )
		{
			await _contactsApiDataSource.GetContacts( callback, queryParams );
		}
	}
}

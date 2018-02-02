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

		public void GetContact( IGetContactCallBack callback, string[ ] extraParams )
		{
			_contactsApiDataSource.GetContact( callback, extraParams );
		}

		public void GetContacts( IGetContactsCallback callback, string[ ] extraParams )
		{
			_contactsApiDataSource.GetContacts( callback, extraParams );
		}
	}
}

using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MvpArchitecture.Classes;
using MvpArchitecture.Data.Models.Contacts;
using MvpArchitecture.Helpers;
using MvpArchitecture.Interfaces;
using Refit;
using static MvpArchitecture.Areas.Contacts.ContactsContract.Data;

namespace MvpArchitecture.Areas.Contacts
{
	public class ContactsApiDataSource : IContactsDataSource
	{
		private IApi _api;

		public ContactsApiDataSource( IApi api )
		{
			_api = api;
		}

		public async Task GetContacts( IGetContactsCallback callback, ContactsQueryParameters queryParams )
		{
			try
			{
				ContactList response = await _api.GetContacts( queryParams );

				ContactListViewModel contactList = new ContactListViewModel( response );

				callback.OnContactsLoaded( contactList );
			}
			catch ( ApiException e )
			{
				if ( e.StatusCode == HttpStatusCode.NotFound )
				{
					callback.OnContactsLoaded( new ContactListViewModel( ) );
				}
				else
				{
					callback.OnDataNotAvailable( );
				}
			}
		}

		public async Task GetContact( IGetContactCallBack callback, string[ ] extraParams )
		{
			throw new System.NotImplementedException( );
		}
	}
}

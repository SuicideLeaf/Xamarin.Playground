using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MvpArchitecture.Classes;
using MvpArchitecture.Data.Models.Contacts;
using MvpArchitecture.Helpers;
using MvpArchitecture.Interfaces;
using static MvpArchitecture.Areas.Contacts.ContactsContract.Data;

namespace MvpArchitecture.Areas.Contacts
{
	public class ContactsApiDataSource : IContactsDataSource
	{
		private IRequestHandler _requestHandler;

		public ContactsApiDataSource( IRequestHandler requestHandler )
		{
			_requestHandler = requestHandler;
		}

		public void GetContacts( IGetContactsCallback callback, string[ ] extraParams )
		{
			string contactsEndPoint = ApiHelper.GetEndPoint( _requestHandler, "LandlordAppContacts", extraParams );

			Task.Run( async ( ) =>
			{
				Response<ContactList> response = await ApiHelper.GetAsync<ContactList>( contactsEndPoint, _requestHandler.ConsumerKey );

				if ( response.Success && response.Model.Contacts.Any( ) || response.StatusCode == HttpStatusCode.NotFound )
				{
					ContactListViewModel contactList = new ContactListViewModel( response.Model );
					callback.OnContactsLoaded( contactList );
				}
				else
				{
					callback.OnDataNotAvailable( );
				}
			} );
		}

		public void GetContact( IGetContactCallBack callback, string[ ] extraParams )
		{
			throw new System.NotImplementedException( );
		}
	}
}

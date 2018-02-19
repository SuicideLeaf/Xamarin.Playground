using System.Threading.Tasks;
using MvpArchitecture.Data.Models.Contacts;

namespace MvpArchitecture.Areas.Contacts
{
	public class ContactsContract
	{
		public interface IContactsView : IApiView<ContactsQueryParameters>
		{
			bool IsActive { get; }
			void ToggleRefreshing( bool active );
			void ToggleLoadingOverlay( bool active );
			void ToggleRetryOverlay( bool active, string message = "" );
			void ShowLoadingOverlay( );
			void ShowLoadingContactsError( );
			void ShowContacts( ContactListViewModel contactList );
			void ShowNoContacts( );
		}

		public interface IContactsPresenter : IBasePresenter
		{
			Task LoadContacts( );
			Task LoadContacts( bool isRefreshing );
			Task LoadContactDetails( );
		}

		public class Data
		{
			public interface IContactsDataSource
			{
				Task GetContacts( IGetContactsCallback callback, ContactsQueryParameters queryParams );
				Task GetContact( IGetContactCallBack callback, string[ ] extraParams );
			}

			public interface IGetContactsCallback : IBaseCallback
			{
				void OnContactsLoaded( ContactListViewModel contactList );
			}

			public interface IGetContactCallBack : IBaseCallback
			{
				void OnContactLoaded( );
			}
		}
	}
}

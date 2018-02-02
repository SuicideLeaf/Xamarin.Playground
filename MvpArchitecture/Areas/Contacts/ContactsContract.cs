using System;
using MvpArchitecture.Data.Models.Contacts;

namespace MvpArchitecture.Areas.Contacts
{
	public class ContactsContract
	{
		public interface IContactsView : IBaseView
		{
			bool IsActive { get; }
			int LeaseId { get; }
			void ToggleRefreshing( bool active );
			void ToggleLoadingOverlay( bool active );
			void ToggleRetryOverlay( bool active, string message = "" );
			void ShowLoadingContactsError( );
			void ShowContacts( ContactListViewModel contactList );
			void ShowNoContacts( );
		}

		public interface IContactsPresenter
		{
			void LoadContacts( );
			void LoadContacts( bool isRefreshing );
			void LoadContactDetails( );
		}

		public class Data
		{
			public interface IContactsDataSource
			{
				void GetContacts( IGetContactsCallback callback, string[ ] extraParams );
				void GetContact( IGetContactCallBack callback, string[ ] extraParams );
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

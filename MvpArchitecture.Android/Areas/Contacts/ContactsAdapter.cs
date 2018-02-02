using System;
using Android.Support.V7.Widget;
using Android.Views;
using MvpArchitecture.Data.Models.Contacts;

namespace MvpArchitecture.Android.Areas.Contacts
{
	public class ContactsAdapter : RecyclerView.Adapter
	{
		private ContactListViewModel _contactList;

		public EventHandler<int> ContactClicked { get; set; }

		public ContactsAdapter( ContactListViewModel contactList )
		{
			SetContacts( contactList );
		}

		public void ReplaceData( ContactListViewModel contactList )
		{
			SetContacts( contactList );
			NotifyDataSetChanged( );
		}

		private void SetContacts( ContactListViewModel contactList )
		{
			_contactList = contactList;
		}

		private Action<object, int> OnClick => ( obj, pos ) =>
		{
			ContactClicked?.Invoke( obj, pos );
		};

		public override int ItemCount => _contactList.Contacts.Count;

		public override void OnBindViewHolder( RecyclerView.ViewHolder holder, int position )
		{
			ContactListItemViewHolder vh = ( ContactListItemViewHolder )holder;
			ContactListItemViewModel contactListItem = _contactList.Contacts[ position ];

			vh.UpdateViews( contactListItem );
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder( ViewGroup parent, int viewType )
		{
			View view = LayoutInflater.From( parent.Context )
				.Inflate( Resource.Layout.contacts_listitem, parent, false );

			return new ContactListItemViewHolder( view, OnClick );
		}
	}
}

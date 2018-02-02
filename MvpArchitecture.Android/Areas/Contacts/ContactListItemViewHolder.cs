using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using MvpArchitecture.Data.Models.Contacts;

namespace MvpArchitecture.Android.Areas.Contacts
{
	public class ContactListItemViewHolder : RecyclerView.ViewHolder
	{
		private readonly View _view;
		private readonly Action<object, int> _onClick;

		public TextView ContactName { get; set; }
		public TextView ContactTypes { get; set; }

		public ContactListItemViewHolder( View view, Action<object, int> onClick )
			: base( view )
		{
			_view = view;
			_onClick = onClick;

			ContactName = view.FindViewById<TextView>( Resource.Id.contacts_listitem_textview_name );
			ContactTypes = view.FindViewById<TextView>( Resource.Id.contacts_listitem_textview_types );
		}

		public void UpdateViews( ContactListItemViewModel contactListItem )
		{
			ContactName.Text = contactListItem.Name;
			ContactTypes.Text = contactListItem.Types;
		}
	}
}

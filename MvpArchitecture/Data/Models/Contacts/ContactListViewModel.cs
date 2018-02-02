using System.Collections.Generic;
using System.Linq;

namespace MvpArchitecture.Data.Models.Contacts
{
	public class ContactListViewModel
	{
		public List<ContactListItemViewModel> Contacts { get; set; }

		public ContactListViewModel( )
		{
			Contacts = new List<ContactListItemViewModel>( );
		}

		public ContactListViewModel( ContactList contactList ) : this( )
		{
			foreach ( ContactListItem contact in contactList.Contacts.OrderBy( o => o.Name ) )
			{
				Contacts.Add( new ContactListItemViewModel( contact ) );
			}
		}
	}

	public class ContactListItemViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Types { get; set; }

		public ContactListItemViewModel( ) { }

		public ContactListItemViewModel( ContactListItem contact )
		{
			Id = contact.Id;
			Name = contact.Name;
			Types = string.Join( ", ", contact.ContactTypes );
		}
	}
}

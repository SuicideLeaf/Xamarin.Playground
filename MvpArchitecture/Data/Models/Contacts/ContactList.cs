using System.Collections.Generic;

namespace MvpArchitecture.Data.Models.Contacts
{
	public class ContactList : BaseModel
	{
		public List<ContactListItem> Contacts { get; set; }
	}

	public class ContactListItem
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<string> ContactTypes { get; set; }
	}
}
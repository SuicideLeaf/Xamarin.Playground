using static MvpArchitecture.Helpers.ApiHelper;

namespace MvpArchitecture.Areas.Contacts
{
	public class ContactsQueryParameters : QueryParameters
	{
		public int LeaseId { get; set; }

		public ContactsQueryParameters( int leaseId )
		{
			LeaseId = leaseId;
		}
	}
}

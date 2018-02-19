using System.Threading.Tasks;
using MvpArchitecture.Areas.Contacts;
using MvpArchitecture.Classes;
using MvpArchitecture.Data.Models.Contacts;
using Refit;

namespace MvpArchitecture.Interfaces
{
	[Headers( "Authorization: Bearer" )]
	public interface IApi
	{
		[Get( "/Api/LandlordAppContacts" )]
		Task<ContactList> GetContacts( ContactsQueryParameters queryParams );
	}
}

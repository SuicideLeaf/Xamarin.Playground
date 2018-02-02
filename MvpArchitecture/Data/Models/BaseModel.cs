namespace MvpArchitecture.Data.Models
{
	public class BaseModel
	{
		public bool CanViewArrears { get; set; }
		public bool CanViewMaintenance { get; set; }
		public bool CanViewEvents { get; set; }
		public bool CanViewTenancyContacts { get; set; }
	}
}

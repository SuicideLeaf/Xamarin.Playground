using System;
using Features.Playground.Core.Classes;

namespace Features.Playground.Core.Models
{
	public class MaintenanceListItem
	{
		public Enums.MaintenanceStatus Status { get; set; }
		public string Title { get; set; }
		public DateTime DueDate { get; set; }

		public bool IsOverDue => Status == Enums.MaintenanceStatus.Incomplete && DueDate < DateTime.Now;
	}
}
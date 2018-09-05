using System;
using System.Collections.Generic;
using System.Linq;
using Features.Playground.Core.Classes;

namespace Features.Playground.Core.Models
{
	public class MaintenanceSection
	{
		public Enums.MaintenanceStatus Status { get; set; }
		public List<MaintenanceListItem> Items { get; set; }

		public MaintenanceSection( Enums.MaintenanceStatus status )
		{
			Status = status;
			Items = new List<MaintenanceListItem>( );

			Random rnd = new Random( );
			var itemCount = rnd.Next( 0, 15 );
			for ( int i = 0; i < itemCount; i++ )
			{
				var month = rnd.Next( 7, 10 );
				var day = rnd.Next( 1, 30 );

				MaintenanceListItem item = new MaintenanceListItem
				{
					Status = status,
					Title = $"Maintenance {i}",
					DueDate = new DateTime( 2018, month, day )
				};

				Items.Add( item );
			}

			Items = Items.OrderBy( m => m.DueDate ).ThenBy( m => m.Title ).ToList();
		}
	}
}
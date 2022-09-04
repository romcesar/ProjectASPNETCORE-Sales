
using SalesWeb.ASPNETCORE.Models.Entities;
using System.Collections.Generic;

namespace SalesWeb.ASPNETCORE.Models.ViewModel
{
	public class SellersFormViewModel
	{
		public Sellers Sellers { get; set; }

		public ICollection<Departaments> Departaments { get; set; }
	}
}

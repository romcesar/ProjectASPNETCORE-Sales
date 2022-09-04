using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SalesWeb.ASPNETCORE.Models.Entities
{
    public class Departaments
    {
        public int Id { get; set; }
        public string name { get; set; }

        public ICollection<Sellers> Sellers { get; set; } = new List<Sellers>();

        public Departaments()
        {

        }

        public Departaments(int id, string name)
        {
            this.Id = id;
            this.name = name;
        }

        public void AddSeller(Sellers sellers)
        {
            Sellers.Add(sellers);
        }

        public double TotalSales(DateTime inicial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(inicial, final));
        }
    }
}

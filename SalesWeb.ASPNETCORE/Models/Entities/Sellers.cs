using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWeb.ASPNETCORE.Models.Entities
{
    public class Sellers
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public DateTime bithDate { get; set; }
        public double baseSalary { get; set; }
        public Departaments departaments { get; set; }
        public ICollection<SalesRecord> sales { get; set; } = new List<SalesRecord>();

        public Sellers()
        {

        }

        public Sellers(int id, string name, string email,DateTime bithDate, double baseSalary, Departaments departaments)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.baseSalary = baseSalary;
            this.bithDate = bithDate;
            this.departaments = departaments;
        }

        public void AddSales(SalesRecord sr)
        {
            sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            sales.Remove(sr);
        }

        public double TotalSales(DateTime inicial, DateTime final)
        {
            return sales.Where(sr => sr.date >= inicial && sr.date <= final).Sum(x => x.amount);
        }
    }
}

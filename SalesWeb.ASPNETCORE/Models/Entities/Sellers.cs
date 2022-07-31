using System;

namespace SalesWeb.ASPNETCORE.Models.Entities
{
    public class Sellers
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public double baseSalary { get; set; }
        public DateTime bithDate { get; set; }
    }
}

using System;
using SalesWeb.ASPNETCORE.Models.enums;

namespace SalesWeb.ASPNETCORE.Models.Entities
{
    public class SalesRecord
    {
        public int id { get; set; }

        public DateTime date { get; set; }

        public double amount { get; set; }

        public SalesStatus SalesStatus  { get; set; }

    }
}

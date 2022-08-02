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

        public Sellers sellers { get; set; }

        public SalesRecord()
        {

        }

        public SalesRecord(int id, DateTime date, double amount, SalesStatus salesStatus, Sellers sellers)
        {
            this.id = id;
            this.date = date;
            this.amount = amount;
            SalesStatus = salesStatus;
            this.sellers = sellers;
        }
    }
}

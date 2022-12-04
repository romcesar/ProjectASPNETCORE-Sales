using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWeb.ASPNETCORE.Models.Entities
{
    public class Sellers
    {
        [Display(Name ="Id")]
        public int id { get; set; }

        [Required(ErrorMessage ="{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Size shoud between {2} and {1}")]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name ="Email")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }


        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Bith Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        public DateTime bithDate { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Salary Base")]
        [DisplayFormat(DataFormatString ="{0:f2}")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        public double baseSalary { get; set; }


        public Departaments departaments { get; set; }
		public int DepartamentsId { get; set; }
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

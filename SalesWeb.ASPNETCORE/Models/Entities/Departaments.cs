using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesWeb.ASPNETCORE.Models.Entities
{
    [Table("Departaments")]
    public class Departaments
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }
}

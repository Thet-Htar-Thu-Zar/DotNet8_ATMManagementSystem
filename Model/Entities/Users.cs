using Model.ApplicationConfig;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    [Table("Tbl_ATMUser")]
    public class Users : Common
    {
        [Key]
        public Guid UserID { get; set; } = new Guid();
        public string? Password { get; set; }
        public string? UserName { get; set; }
        public decimal? Amount { get; set;}
    }
}

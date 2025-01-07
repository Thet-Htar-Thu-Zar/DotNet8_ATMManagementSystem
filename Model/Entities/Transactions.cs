using Model.ApplicationConfig;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    [Table("Tbl_Transactions")]
    public class Transactions : Common
    {
        [Key]
        public Guid TransactionID { get; set; } = Guid.NewGuid();
        public Guid UserID { get; set; }
        public string TransactionType { get; set; }
        public decimal TransactionAmount { get; set; }
    }
}

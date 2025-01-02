using Model.ApplicationConfig;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    [Table("Tbl_StoreFile")]
    public class Files : Common
    {
        [Key]
        public Guid FileID { get; set; } = new Guid();     
        public string? FileName { get; set; }
        public string? Uri { get; set; }
        public string? Content_Type { get; set; }
    }
}

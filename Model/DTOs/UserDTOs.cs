using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class CreateUserDTOs
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public decimal? Amount { get; set; }
        public string? CreatedBy { get; set; }
    }

    public class UpdateUserDTOs
    {
        public Guid UserID { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public decimal? Amount { get; set; }
        public string? UpdatedBy { get; set; }

    }
}

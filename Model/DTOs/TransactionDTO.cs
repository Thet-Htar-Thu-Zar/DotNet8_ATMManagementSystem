using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class CreateTransactionDTOs
    {     
            public Guid UserID { get; set; }
            public decimal TransactionAmount { get; set; }
    }
}

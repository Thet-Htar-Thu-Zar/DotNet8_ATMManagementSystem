namespace Model.DTOs
{
    public class CreateTransactionDTOs
    {     
            public Guid UserID { get; set; }
            public decimal TransactionAmount { get; set; }
    }
}

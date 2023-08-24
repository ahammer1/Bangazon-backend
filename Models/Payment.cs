namespace BangAzon.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string PaymentTypeId { get; set; }

        public User UserId { get; set; }
    }
}

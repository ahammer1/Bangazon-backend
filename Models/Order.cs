using System.ComponentModel.DataAnnotations;

namespace BangAzon.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set;}
        public int OrderStatus { get; set; }
        public int OrderStatusId { get; set;}
        public Payment PaymentType { get; set; }


    }
}

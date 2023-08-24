namespace BangAzon.Models
{
    public class OrderStatus
    {
        public static int Processing { get; internal set; }
        public static int Completed { get; internal set; }
        public int OrderStatusId { get; set; }
        public string Name { get; set; }

    }
}

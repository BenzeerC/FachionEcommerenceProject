using System.ComponentModel.DataAnnotations.Schema;

namespace Fachion.Models
{
    public class Order
    {
       
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        [NotMapped]
        public DateTime? ShipDate { get; set; }
        [NotMapped]
        public decimal TotalAmount { get; set; }
        [NotMapped]
        public string PaymentMethod { get; set; }
        [NotMapped]
        public string OrderStatus { get; set; }
        [NotMapped]
        public string ShippingAddress { get; set; }
        [NotMapped]
        public string BillingAddress { get; set; }
    }

}

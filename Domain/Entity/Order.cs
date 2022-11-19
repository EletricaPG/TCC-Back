using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Order
    {
        public string Id           { get; set; } = Guid.NewGuid().ToString();
        public DateTime Date       { get; set; } 
        public string IdPayment { get; set; } 

        public string IdClient { get; set; }  
         public List<OrderDetails> ListOrderDetails {get; set;}
        [Column (TypeName = "decimal(18,2)")] public decimal ValueTotal  { get; set; } 

        //  public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
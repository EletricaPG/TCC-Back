using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entity;

namespace Domain.Model
{
    public class OrderModel
    {   
        public string Id           { get; set; } = Guid.NewGuid().ToString();
        public DateTime Date       { get; set; } //Data e hora do Pedido

        public string IdPayment { get; set; } 
    
        public string IdClient { get; set; }  
          
        public List<OrderDetails> ListOrderDetails {get; set;}

        [Column (TypeName = "decimal(18,2)")] public decimal ValueTotal  { get; set; } 
        // public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
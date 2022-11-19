using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entity;

namespace Domain.Model
{
    public class OrderDetailsModel
    {
           
        public string Id  { get; set; } = Guid.NewGuid().ToString();
        //  public string OrderId { get; set; }

        // public Order Order{get;}
        public string  IdProduct { get; set; }
        public int AmountOrder { get; set; }
      
        [Column(TypeName = "decimal(18,2)")] public decimal ValueUni { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal SubTotal { get; set; }
    }
}
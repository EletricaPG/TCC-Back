using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Buy
    {
         public string Id { get; set; } = Guid.NewGuid().ToString();
        public  DateTime Date { get; set; } //Data da compra 
        
        [Column (TypeName = "decimal(18,2)")]
        public decimal ValueTotal { get; set; } // Valor total da compra
        
        
       
         
        
   
    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Product
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
         public string Description { get; set; }
         
         [Column (TypeName = "decimal(18,2)")] public decimal Price { get; set; }
        public  string CategoryId { get; set; } // Categoria do produto 
        public int  Amount{ get; set; } // Quantidade de Produtos 
         public string UrlArquivo { get; set; }  
         public string  IdSupplier { get; set;} // Id do Fornecedor 
    }
}
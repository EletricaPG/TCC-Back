namespace Domain.Entity
{
    public class Supplier
    {
           
        //Fornecedor
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "";
        public string Cnpj { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Email { get; set; } = "";
        public string NameCompany { get; set; } = "";//Nome da Empresa
        public string IdSupplier { get; set; } = "";
    }
}
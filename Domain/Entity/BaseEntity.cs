namespace Domain.Entity
{
    public class BaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Description { get; set; } = ""; //Descrição
    }
}
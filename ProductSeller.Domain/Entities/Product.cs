namespace ProductSeller.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public decimal? Value { get; set; }

        public Product(int id, string name, decimal? value)
        {
            Id = id;
            Name = name;
            Value = value;
        }
    }
}
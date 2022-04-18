namespace ProductSeller.Domain.Interfaces
{
    public interface IDatabaseContext
    {
        string MySqlConnectionString { get; set; }
    }
}
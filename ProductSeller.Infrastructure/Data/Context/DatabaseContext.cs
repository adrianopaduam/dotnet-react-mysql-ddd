
using ProductSeller.Domain.Interfaces;

namespace ProductSeller.Infrastructure.Data.Context
{
    public class DatabaseContext : IDatabaseContext
    {
        public const string SectionName = "ConnectionStrings";

        public string MySqlConnectionString { get; set; }
    }
}

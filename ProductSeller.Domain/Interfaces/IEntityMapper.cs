using MySql.Data.MySqlClient;
using ProductSeller.Domain.Entities;

namespace ProductSeller.Domain.Interfaces
{
    public interface IEntityMapper<out TEntity> where TEntity : BaseEntity
    {
        TEntity Map(MySqlDataReader dataReader);
    }
}
using ProductSeller.Domain.Entities;
using MySql.Data.MySqlClient;


namespace ProductSeller.Domain.Interfaces
{
    public interface IEntityMapper<out TEntity> where TEntity : BaseEntity
    {
        TEntity Map(MySqlDataReader dataReader);
    }
}

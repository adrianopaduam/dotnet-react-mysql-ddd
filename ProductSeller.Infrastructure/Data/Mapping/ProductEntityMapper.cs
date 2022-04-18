using MySql.Data.MySqlClient;
using ProductSeller.Domain.Entities;
using ProductSeller.Domain.Interfaces;


namespace ProductSeller.Infrastructure.Data.Mapping
{
    public class ProductEntityMapper<TEntity> : IEntityMapper<TEntity> where TEntity : Product
    {
        public TEntity Map(MySqlDataReader dataReader)
        {
            Product mappedProduct = new(
                id: dataReader.GetInt32(0),
                name: dataReader.GetString(1),
                value: dataReader.GetDecimal(2)
            );
            return (TEntity)mappedProduct;
        }
    }
}

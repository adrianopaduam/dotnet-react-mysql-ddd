using ProductSeller.Domain.Entities;
using System.Data.SqlClient;


namespace ProductSeller.Domain.Interfaces
{
    public interface IEntityMapper<TEntity> where TEntity : BaseEntity
    {
        TEntity Map(SqlDataReader dataReader);
    }
}

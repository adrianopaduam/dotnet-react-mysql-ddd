using ProductSeller.Domain.Entities;
using System.Data.SqlClient;

namespace ProductSeller.Domain.Interfaces
{
    public interface IQueryBuilder<TEntity> where TEntity : BaseEntity
    {
        SqlCommand CreateQuery(SqlConnection sqlConnection, TEntity entity);

        SqlCommand UpdateQuery(SqlConnection sqlConnection, TEntity entity);

        SqlCommand DeleteQuery(SqlConnection sqlConnection, int id);

        SqlCommand GetAllQuery(SqlConnection sqlConnection);

        SqlCommand GetByIdQuery(SqlConnection sqlConnection, int id);
    }
}

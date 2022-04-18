using MySql.Data.MySqlClient;
using ProductSeller.Domain.Entities;

namespace ProductSeller.Domain.Interfaces
{
    public interface IQueryBuilder<in TEntity> where TEntity : BaseEntity
    {
        MySqlCommand CreateQuery(MySqlConnection sqlConnection, TEntity entity);

        MySqlCommand UpdateQuery(MySqlConnection sqlConnection, TEntity entity);

        MySqlCommand DeleteQuery(MySqlConnection sqlConnection, int id);

        MySqlCommand GetAllQuery(MySqlConnection sqlConnection);

        MySqlCommand GetByIdQuery(MySqlConnection sqlConnection, int id);
    }
}

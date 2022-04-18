using MySql.Data.MySqlClient;
using ProductSeller.Domain.Entities;
using ProductSeller.Domain.Interfaces;

namespace ProductSeller.Infrastructure.Data.Query
{
    public class ProductQueryBuilder<TEntity> : IQueryBuilder<TEntity> where TEntity : Product
    {
        public MySqlCommand CreateQuery(MySqlConnection sqlConnection, TEntity entity)
        {
            MySqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = $"INSERT INTO products(name, value) VALUES ('{entity.Name}', '{entity.Value}')";
            return sqlCommand;
        }

        public MySqlCommand DeleteQuery(MySqlConnection sqlConnection, int id)
        {
            MySqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = $"DELETE FROM products WHERE id = {id}";
            return sqlCommand;
        }

        public MySqlCommand GetAllQuery(MySqlConnection sqlConnection)
        {
            MySqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT id, name, value FROM products LIMIT 1000";
            return sqlCommand;
        }

        public MySqlCommand GetByIdQuery(MySqlConnection sqlConnection, int id)
        {
            MySqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = $"SELECT id, name, value FROM products WHERE id = {id}";
            return sqlCommand;
        }

        public MySqlCommand UpdateQuery(MySqlConnection sqlConnection, TEntity entity)
        {
            string updateQuery = "UPDATE products";
            bool useComma = false;

            if (entity.Name != null && entity.Name?.Length > 0)
            {
                updateQuery = updateQuery + $" SET name = '{entity.Name}'";
                useComma = true;
            }

            if (entity.Value != null)
            {
                string separator = useComma ? ", " : "SET ";
                updateQuery = updateQuery + separator + $" value = '{entity.Value}'";
            }

            updateQuery = updateQuery + $" WHERE id = '{entity.Id}'";

            MySqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = updateQuery;
            return sqlCommand;
        }
    }
}
using MySql.Data.MySqlClient;
using ProductSeller.Domain.Entities;
using ProductSeller.Domain.Interfaces;

namespace ProductSeller.Infrastructure.Data.Query
{
    public class UserQueryBuilder<TEntity> : IQueryBuilder<TEntity> where TEntity : User
    {
        public MySqlCommand CreateQuery(MySqlConnection sqlConnection, TEntity entity)
        {
            MySqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = $"INSERT INTO users(name, email, password) VALUES ('{entity.Name}', '{entity.Email}', '{entity.Password.GetHashCode()}')";
            return sqlCommand;
        }

        public MySqlCommand DeleteQuery(MySqlConnection sqlConnection, int id)
        {
            MySqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = $"DELETE FROM users WHERE id = {id}";
            return sqlCommand;
        }

        public MySqlCommand GetAllQuery(MySqlConnection sqlConnection)
        {
            MySqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT id, name, email, password FROM users LIMIT 1000";
            return sqlCommand;
        }

        public MySqlCommand GetByIdQuery(MySqlConnection sqlConnection, int id)
        {
            MySqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = $"SELECT id, name, email, password FROM users WHERE id = {id}";
            return sqlCommand;
        }

        public MySqlCommand UpdateQuery(MySqlConnection sqlConnection, TEntity entity)
        {
            string updateQuery = "UPDATE users";
            bool useComma = false;

            if (entity.Name != null && entity.Name?.Length > 0)
            {
                updateQuery = updateQuery + $" SET name = '{entity.Name}'";
                useComma = true;
            }

            if (entity.Email != null && entity.Email?.Length > 0)
            {
                string separator = useComma ? ", " : "SET ";
                updateQuery = updateQuery + separator + $" email = '{entity.Email}'";
            }

            if (entity.Password != null && entity.Password?.Length > 0)
            {
                string separator = useComma ? ", " : "SET ";
                updateQuery = updateQuery + separator + $" password = '{entity.Password?.GetHashCode()}'";
            }

            updateQuery = updateQuery + $" WHERE id = '{entity.Id}'";

            MySqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = updateQuery;
            return sqlCommand;
        }
    }
}
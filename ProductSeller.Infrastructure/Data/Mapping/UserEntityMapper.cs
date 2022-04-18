using MySql.Data.MySqlClient;
using ProductSeller.Domain.Entities;
using ProductSeller.Domain.Interfaces;

namespace ProductSeller.Infrastructure.Data.Mapping
{
    public class UserEntityMapper<TEntity> : IEntityMapper<TEntity> where TEntity : User
    {
        public TEntity Map(MySqlDataReader dataReader)
        {
            User mappedUser = new(
                id: dataReader.GetInt32(0),
                name: dataReader.GetString(1),
                email: dataReader.GetString(2),
                password: dataReader.GetString(3)
            );
            return (TEntity)mappedUser;
        }
    }
}

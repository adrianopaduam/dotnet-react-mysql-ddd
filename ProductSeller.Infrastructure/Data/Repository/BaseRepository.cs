using MySql.Data.MySqlClient;
using ProductSeller.Domain.Entities;
using ProductSeller.Domain.Interfaces;

namespace ProductSeller.Infrastructure.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly MySqlConnection _sqlConnection;

        private readonly IQueryBuilder<TEntity> _queryBuilder;

        private readonly IEntityMapper<TEntity> _entityMapper;

        public BaseRepository(IDatabaseContext databaseContext, IQueryBuilder<TEntity> queryBuilder, IEntityMapper<TEntity> mapper)
        {
            _sqlConnection = new MySqlConnection(databaseContext.MySqlConnectionString);

            _queryBuilder = queryBuilder;

            _entityMapper = mapper;
        }

        public void Add(TEntity entity)
        {
            MySqlCommand command = _queryBuilder.CreateQuery(_sqlConnection, entity);

            _sqlConnection.Open();
            MySqlTransaction transaction = _sqlConnection.BeginTransaction();
            try
            {
                command.Transaction = transaction;
                _ = command.ExecuteNonQuery();
                transaction.Commit();
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public bool Delete(int id)
        {
            MySqlCommand command = _queryBuilder.DeleteQuery(_sqlConnection, id);

            int rowsAffected = 0;
            _sqlConnection.Open();
            MySqlTransaction transaction = _sqlConnection.BeginTransaction();
            try
            {
                command.Transaction = transaction;
                rowsAffected = command.ExecuteNonQuery();
                transaction.Commit();
            }
            finally
            {
                _sqlConnection.Close();
            }

            return Convert.ToBoolean(rowsAffected);
        }

        public IList<TEntity> GetAll()
        {
            List<TEntity> allRecordsList = new List<TEntity>();

            MySqlCommand command = _queryBuilder.GetAllQuery(_sqlConnection);

            _sqlConnection.Open();
            MySqlTransaction transaction = _sqlConnection.BeginTransaction();
            try
            {
                command.Transaction = transaction;
                var reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        allRecordsList.Add(_entityMapper.Map(reader));
                    }
                }
                finally
                {
                    reader.Close();
                }

                transaction.Commit();
            }
            finally
            {
                _sqlConnection.Close();
            }

            return allRecordsList;
        }

        public TEntity? GetById(int id)
        {
            TEntity? record = null;

            MySqlCommand command = _queryBuilder.GetByIdQuery(_sqlConnection, id);

            _sqlConnection.Open();
            MySqlTransaction transaction = _sqlConnection.BeginTransaction();
            try
            {
                command.Transaction = transaction;
                var reader = command.ExecuteReader();
                try
                {
                    reader.Read();
                    record = _entityMapper.Map(reader);
                }
                finally
                {
                    reader.Close();
                }

                transaction.Commit();
            }
            finally
            {
                _sqlConnection.Close();
            }

            return record;
        }

        public void Update(TEntity entity)
        {
            MySqlCommand command = _queryBuilder.UpdateQuery(_sqlConnection, entity);

            _sqlConnection.Open();
            MySqlTransaction transaction = _sqlConnection.BeginTransaction();
            try
            {
                command.Transaction = transaction;
                _ = command.ExecuteNonQuery();
                transaction.Commit();
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
    }
}
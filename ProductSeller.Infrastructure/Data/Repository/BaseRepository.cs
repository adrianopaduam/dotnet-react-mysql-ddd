using ProductSeller.Domain.Entities;
using ProductSeller.Domain.Interfaces;
using System.Data.SqlClient;


namespace ProductSeller.Infrastructure.Data.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private static SqlConnection _sqlConnection;

        private IQueryBuilder<TEntity> _queryBuilder;

        private IEntityMapper<TEntity> _entityMapper;

        public BaseRepository(string connectionString, IQueryBuilder<TEntity> queryBuilder, IEntityMapper<TEntity> mapper)
        {
            _sqlConnection = new SqlConnection(connectionString);
            if (_sqlConnection == null)
            {
                throw new Exception("Improve HERE");
            }

            _queryBuilder = queryBuilder;

            _entityMapper = mapper;
        }


        public void Add(TEntity entity)
        {
            SqlCommand command = _queryBuilder.CreateQuery(_sqlConnection, entity);

            SqlTransaction transaction = _sqlConnection.BeginTransaction();
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
            SqlCommand command = _queryBuilder.DeleteQuery(_sqlConnection, id);

            int rowsAffected = 0;
            SqlTransaction transaction = _sqlConnection.BeginTransaction();
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

            SqlCommand command = _queryBuilder.GetAllQuery(_sqlConnection);
            SqlTransaction transaction = _sqlConnection.BeginTransaction();
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

            SqlCommand command = _queryBuilder.GetByIdQuery(_sqlConnection, id);
            SqlTransaction transaction = _sqlConnection.BeginTransaction();
            try
            {
                command.Transaction = transaction;
                var reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        record = _entityMapper.Map(reader);
                        break;
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

            return record;
        }

        public void Update(TEntity entity)
        {
            SqlCommand command = _queryBuilder.UpdateQuery(_sqlConnection, entity);

            SqlTransaction transaction = _sqlConnection.BeginTransaction();
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

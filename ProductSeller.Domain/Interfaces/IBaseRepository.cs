using ProductSeller.Domain.Entities;


namespace ProductSeller.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        bool Delete(int id);

        IList<TEntity> GetAll();

        TEntity? GetById(int id);
    }
}

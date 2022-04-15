using FluentValidation;
using ProductSeller.Domain.Entities;

namespace ProductSeller.Domain.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        TEntity Add<TValidator>(TEntity entity) where TValidator : AbstractValidator<TEntity>;
        
        TEntity Update<TValidator>(TEntity entity) where TValidator : AbstractValidator<TEntity>;

        void Delete(int id);

        IList<TEntity> GetAll();

        TEntity GetById(int id);
    }
}

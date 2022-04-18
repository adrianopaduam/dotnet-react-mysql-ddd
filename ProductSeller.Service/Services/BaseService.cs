using FluentValidation;
using ProductSeller.Domain.Entities;
using ProductSeller.Domain.Interfaces;

namespace ProductSeller.Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public TEntity Add<TValidator>(TEntity entity) where TValidator : AbstractValidator<TEntity>
        {
            Validate(entity, Activator.CreateInstance<TValidator>());
            _baseRepository.Add(entity);
            return entity;
        }

        public bool Delete(int id) => _baseRepository.Delete(id);

        public IList<TEntity> GetAll() => _baseRepository.GetAll();

        public TEntity? GetById(int id) => _baseRepository.GetById(id);

        public TEntity Update<TValidator>(TEntity entity) where TValidator : AbstractValidator<TEntity>
        {
            Validate(entity, Activator.CreateInstance<TValidator>());
            _baseRepository.Update(entity);
            return entity;
        }

        private void Validate(TEntity entity, AbstractValidator<TEntity> validator)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            validator.ValidateAndThrow(entity);
        }
    }
}
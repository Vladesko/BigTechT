using Application.Interfaces;
using Persistance;
using Persistance.Repositories;

namespace Products.Tests.Persistance.Repository
{
    public abstract class BaseTestRepository : IDisposable
    {
        protected readonly ApplicationDbContext _context;
        protected readonly IProductRepository _repository;
        protected BaseTestRepository()
        {
            _context = DbContextFactory.GetContext();
            _repository = new ProductRepository(_context);
        }
        public void Dispose()
        {
            DbContextFactory.Destroy(_context);
            GC.SuppressFinalize(this);
        }
    }
}

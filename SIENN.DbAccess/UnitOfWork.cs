using System;
using SIENN.DbAccess.Entities;
using SIENN.DbAccess.Repositories;

namespace SIENN.DbAccess
{
    public class UnitOfWork : IDisposable
    {
        private DatabaseContext _context;
        private IGenericRepository<Unit> unitRepository;
        private IGenericRepository<ProductType> productTypeRepository;
        private IGenericRepository<Category> categoryRepository;
        private IGenericRepository<Product> productRepository;

        public IGenericRepository<Unit> UnitRepository
        {
            get
            {
                if (this.unitRepository == null)
                {
                    this.unitRepository = new GenericRepository<Unit>(_context);
                }
                return unitRepository;
            }
        }

        public IGenericRepository<ProductType> ProductTypeRepository
        {
            get
            {
                if (this.productTypeRepository == null)
                {
                    this.productTypeRepository = new GenericRepository<ProductType>(_context);
                }
                return productTypeRepository;
            }
        }

        public IGenericRepository<Category> CategoryRepository
        {
            get
            {
                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new GenericRepository<Category>(_context);
                }
                return categoryRepository;
            }
        }

        public IGenericRepository<Product> ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                {
                    this.productRepository = new GenericRepository<Product>(_context);
                }
                return productRepository;
            }
        }

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

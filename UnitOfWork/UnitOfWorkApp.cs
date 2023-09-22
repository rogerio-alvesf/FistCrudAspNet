using FistCrudAspNet.Data;
using FistCrudAspNet.Models;
using FistCrudAspNet.Repository;
using Microsoft.EntityFrameworkCore;
using System;

namespace FistCrudAspNet.UnitOfWork
{
    public class UnitOfWorkApp : IDisposable
    {
        private readonly ContextApp _contextApp;
        private Repository<Product> _productRepository;

        public UnitOfWorkApp(ContextApp contextApp)
        {
            _contextApp = contextApp ?? throw new ArgumentNullException(nameof(contextApp));
        }

        public Repository<Product> ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new Repository<Product>(_contextApp);
                }
                return _productRepository;
            }
        }

        public void Dispose()
        {
            _contextApp.Dispose();
        }
    }
}

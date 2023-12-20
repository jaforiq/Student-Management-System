using SMS.Core.Interface;
using SMS.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SMSDbContext _dbContext;

        //public ISMSRepository Products => throw new NotImplementedException();

        public ISMSRepository Products { get; }

        public UnitOfWork(SMSDbContext dbContext, ISMSRepository products)
        {
            _dbContext = dbContext;
            Products = products;
            //Products = productRepository;
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

    }
}

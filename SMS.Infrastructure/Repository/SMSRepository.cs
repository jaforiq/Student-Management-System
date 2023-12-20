using SMS.Core;
using SMS.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Repository
{
    public class SMSRepository : GenericRepository<StudentModel>, ISMSRepository
    {
        public SMSRepository(SMSDbContext dbContext) : base(dbContext)
        {

        }
    }
}

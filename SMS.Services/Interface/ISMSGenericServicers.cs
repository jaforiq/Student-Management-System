using SMS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSServices.Interface
{
    public interface ISMSGenericServicers<T> where T : class
    {
        Task Add(T obj);
        Task<T> GetByID(string id);
        void Delete(T obj);
        void Update(T obj);
        Task<IEnumerable<T>> GetAll();
        
    }
}

using SMS.Core;
using SMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services.Interface
{
    public interface ISMSService
    {
        void Add(StudentModel newItem);
        bool Delete(string id);
        StudentModel GetByID(string id);
        bool Update(string id, StudentModel updateItem);
        IEnumerable<StudentModel> GetAll();
    }
}

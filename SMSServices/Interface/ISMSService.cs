using SMS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services.Interface
{
    public interface ISMSService
    {
        Task<bool> CreateProduct(StudentModel productDetails);

        Task<IEnumerable<StudentModel>> GetAllProducts();

        Task<StudentModel> GetProductById(int productId);

        Task<bool> UpdateProduct(StudentModel productDetails);

        Task<bool> DeleteProduct(int productId);

        //void Add(StudentModel newItem);
        //bool Delete(string id);
        //IEnumerable<StudentModel> GetAll();
        //StudentModel GetByID(string id);
        //bool Update(string id, StudentModel updatedItem);
    }
}

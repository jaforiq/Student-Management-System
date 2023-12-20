using SMS.Core;
using SMS.Core.Interface;
using SMS.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services
{
    public class SMSService : ISMSService
    {
        public IUnitOfWork _unitOfWork;

        public SMSService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateProduct(StudentModel productDetails)
        {
            if (productDetails != null)
            {
                await _unitOfWork.Products.Add(productDetails);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            if (productId > 0)
            {
                var productDetails = await _unitOfWork.Products.GetById(productId);
                if (productDetails != null)
                {
                    _unitOfWork.Products.Delete(productDetails);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<StudentModel>> GetAllProducts()
        {
            var productDetailsList = await _unitOfWork.Products.GetAll();
            return productDetailsList;
        }

        public async Task<StudentModel> GetProductById(int productId)
        {
            if (productId > 0)
            {
                var productDetails = await _unitOfWork.Products.GetById(productId);
                if (productDetails != null)
                {
                    return productDetails;
                }
            }
            return null;
        }

        public Task<bool> UpdateProduct(StudentModel productDetails)
        {
            throw new NotImplementedException();
        }

        //public async Task<bool> UpdateProduct(StudentModel productDetails)
        //{
        //    if (productDetails != null)
        //    {
        //        var product = await _unitOfWork.Products.GetById(productDetails.Id);
        //        if (product != null)
        //        {
        //            product.ProductName = productDetails.ProductName;
        //            product.ProductDescription = productDetails.ProductDescription;
        //            product.ProductPrice = productDetails.ProductPrice;
        //            product.ProductStock = productDetails.ProductStock;

        //            _unitOfWork.Products.Update(product);

        //            var result = _unitOfWork.Save();

        //            if (result > 0)
        //                return true;
        //            else
        //                return false;
        //        }
        //    }
        //    return false;
        //}
    }
}

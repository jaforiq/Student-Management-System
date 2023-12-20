using Microsoft.AspNetCore.Mvc;
using SMS.Core;
using SMS.Core.Models;
using SMS.Services.Interface;
using SMS.Services.Interface;

namespace StudentManageSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SMSController : ControllerBase
    {
        public readonly ISMSService _productService;
        public SMSController(ISMSService productService)
        {
            _productService = productService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetProductList()
        {
            var productDetailsList = await _productService.GetAllProducts();
            if (productDetailsList == null)
            {
                return NotFound();
            }
            return Ok(productDetailsList);
        }

       
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            var productDetails = await _productService.GetProductById(productId);

            if (productDetails != null)
            {
                return Ok(productDetails);
            }
            else
            {
                return BadRequest();
            }
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] StudentModel productDetails)
        {
            //StudentModel student = productDetails;
            var isProductCreated = await _productService.CreateProduct(productDetails);

            if (isProductCreated)
            {
                return Ok(isProductCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(StudentModel productDetails)
        {
            if (productDetails != null)
            {
                var isProductCreated = await _productService.UpdateProduct(productDetails);
                if (isProductCreated)
                {
                    return Ok(isProductCreated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        
        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var isProductCreated = await _productService.DeleteProduct(productId);

            if (isProductCreated)
            {
                return Ok(isProductCreated);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.Models;

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        ProductClass product = new ProductClass();

        [HttpGet]
        [Route("/productlist/all")]
        public IActionResult GetAllProducts()
        {
            return Ok(product.GetAllProductList());
        }

        [HttpGet]
        [Route("/productcartlist/all")]
        public IActionResult GetAllProductsINCart()
        {
            return Ok(product.GetAllCartProducts());
        }

        [HttpGet]
        [Route("/productlist/Name/{pName}")]
        public IActionResult GetProductByName(string pName)
        {
            try
            {
                var prodlist = product.GetProductByName(pName);
                return Ok(prodlist);
            }catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("/productlist/val/{val}")]
        public IActionResult GetProductInStock(bool val)
        {
            try
            {
                var prodlist = product.GetProductInStock(val);
                return Ok(prodlist);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("/productlist/category/{cato}")]
        public IActionResult GetProductBycato(string cato)
        {
            try
            {
                var prodlist = product.GetProductByCategory(cato);
                return Ok(prodlist);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPost]
        [Route("/productlist/add")]
        public IActionResult AddProduct([FromBody]ProductClass newProd)
        {
            return Created("",product.AddProduct(newProd));
        }

        [HttpPost]
        [Route("/productcartlist/addtoCart/{prodId}")]
        public IActionResult AddProductINcart(int prodId)
        {
            try
            {
                var val = product.AddProductInCart(prodId);
                return Created("",val);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("/productlist/update")]
        public IActionResult UpdateProduct([FromBody]ProductClass product)
        {
            try
            {
                var val = product.UppdateProduct(product);
                return Accepted(val);
            }catch (Exception e) 
            { 
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("/productlist/remove/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var val = product.DeleteProduct(id);
                return Accepted(val);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

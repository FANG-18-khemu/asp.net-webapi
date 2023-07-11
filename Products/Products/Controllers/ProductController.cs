using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

namespace Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        static List<String> sportsProducts = new List<String>() { "Bat", "Ball", "Football", "Shoes", "ToyCars" };

        
        [HttpGet]
        [Route("/Products/all")]
        public IActionResult GetAllProducts()
        {
            return Ok(sportsProducts);
        }

        [HttpGet]
        [Route("/Products/position/{position}")]
        public IActionResult GetProductsWithId(int position)
        {
            try
            {
                return Ok(sportsProducts[position]);
            }
            catch(Exception ex)
            {
                return BadRequest("The position enterend is wrong" + ex.Message);
            }
        }

        [HttpGet]
        [Route("/Products/name")]
        public IActionResult GetAllProducts(string name)
        {
            var productName = from v in sportsProducts where v.ToUpper().Equals(name.ToUpper()) select v;
            return Ok(productName);
        }

        [HttpPost]
        [Route("/Products/addProduct")]
        public IActionResult AddProduct(string productName)
        {
            sportsProducts.Add(productName);
            return Created("/Products/all", productName + " this is added to the list ");
        }

        [HttpDelete]
        [Route("/Products/removeProduct/{index}")]
        public IActionResult DeleteProductAtIndex(int index)
        {
            var product = sportsProducts[index];
            sportsProducts.RemoveAt(index);
            return Accepted(product + "is removed from the list");
        }

        [HttpDelete]
        [Route("/Products/removeProductByName/{name}")]
        public IActionResult DeleteProductAtIndex(string name)
        {
            var productName = from v in sportsProducts where v.ToUpper().Equals(name.ToUpper()) select v;
            if (productName != null)
            {
                sportsProducts.Remove(name);
                return Accepted(name + "is removed from the list");
            }
            else
                return NotFound("name was not there to delete");
        }


        [HttpPut]
        [Route("/products/update/{productName}/{newname}")]
        public IActionResult PutProduct(string productName,string newname)
        {

           var val = sportsProducts.FindIndex(va => va.ToUpper() == productName.ToUpper());
     
            if(val == -1)
            {
                return NotFound("Name of the product to be updated is not found");
            }
            sportsProducts[val] = newname;
            return Accepted("product name has been changed from " + productName + " to " + newname );
        }


    }
}

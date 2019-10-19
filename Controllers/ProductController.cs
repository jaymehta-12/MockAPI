using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace ProductMan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> ProductMan = new List<Product>
        {
            new Product
            {
                Term= "Oneplus6T",
                Date = "Launched in November 2018"
            },
            new Product
            {
                Term= "iPhone 11",
                Date = "Launched in September 2019  "
            },
            
        };
    

        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            return Ok(ProductMan);
        }

        [HttpGet]
        [Route("{term}")]
        public ActionResult<Product > Get(string term)
        {
            var prdct = ProductMan.Find(item =>
                    item.Term.Equals(term, StringComparison.InvariantCultureIgnoreCase));

            if (prdct == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(prdct);
            }
        }


        


    }
}
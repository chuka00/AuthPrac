using AuthPrac.Data;
using AuthPrac.Dto;
using AuthPrac.Entities;
using AuthPrac.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AuthPrac.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;

        public ProductController(IProductRepository productRepository, IMapper mapper, AppDbContext appDbContext)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        /*/// <summary>
/// Gets the list of all companies
/// </summary>
/// <returns>The companies list</returns>
[HttpGet(Name = "GetCompanies")]
*/

        /// <summary>
        /// Gets lists of all the products
        /// </summary>
        /// <returns>The product lists</returns>
        [HttpGet]
        //[ProducesResponseType(200, Type = typeof(ICollection<Product>))]
        [Route("products")]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation]
        [Produces("application/json")]
        public IActionResult GetProducts()
        {
            var products = _mapper.Map<List<ProductDto>>(_productRepository.GetProducts());

            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return Ok(products);
        }

        /// <summary>
        /// Creates a new product
        /// </summary>
        /// <returns>A new product</returns>
        [HttpPost]
        public IActionResult CreateProduct(ProductDto product)
        {
          var response =  _productRepository.CreateProduct(product);

            if (response.Result == "Success")
            {
                return Created("Get", product.ProductId);
                 
            }
            return Ok("Could not create product!");
        }



        /// <summary>
        /// Gets the product by Id
        /// </summary>
        /// <returns>The product lists</returns>
        [HttpGet("{prodId}")]
        [ProducesResponseType(200, Type = typeof(Product))]
        [ProducesResponseType(400)]
        public IActionResult GetProduct(int prodId)
        {
            if (!_productRepository.ProductExist(prodId))
                return NotFound();

            var product = _mapper.Map<ProductDto>(_productRepository.GetProduct(prodId));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(product);
        }



    }
}

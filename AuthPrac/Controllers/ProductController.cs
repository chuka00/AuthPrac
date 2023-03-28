using AuthPrac.Data;
using AuthPrac.Dto;
using AuthPrac.Entities;
using AuthPrac.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Product>))]
        public IActionResult GetProducts()
        {
            var products = _mapper.Map<List<ProductDto>>(_productRepository.GetProducts());

            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return Ok(products);
        }
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

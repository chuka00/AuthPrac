﻿using AuthPrac.Dto;
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

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
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

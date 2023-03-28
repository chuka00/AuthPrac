using AuthPrac.Dto;
using AuthPrac.Entities;
using AuthPrac.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AuthPrac.Controllers
{
    /*[Route("api/[controller]")]
    [ApiController]*/
    public class CustomerController : Controller
    {
        
         private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Customer>))]
        public IActionResult GetCustomers()
        {
            var customers = _mapper.Map<List<CustomerDto>>(_customerRepository.GetCustomers());

            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return Ok(customers);
        }



        [HttpGet("{custId}")]
        [ProducesResponseType(200, Type = typeof(Customer))]
        [ProducesResponseType(400)]
        public IActionResult GetCustomer(int custId)
        {
            if (!_customerRepository.CustomerExist(custId))
                return NotFound();

            var customer = _mapper.Map<CustomerDto>(_customerRepository.GetCustomer(custId));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(customer);
        }
         
        /*public IActionResult Index()
        {
            return View();
        }*/
    }
}

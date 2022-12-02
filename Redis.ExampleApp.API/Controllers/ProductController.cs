using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Redis.ExampleApp.API.Models;
using Redis.ExampleApp.API.Models.Repositories;
using Redis.ExampleApp.Cache;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Redis.ExampleApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly RedisService _redisService;
        public ProductController(IProductRepository productRepository, RedisService redisService)
        {
            _productRepository = productRepository;
            _redisService = redisService;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var db = _redisService.GetDb(4);
            db.StringSet("test", "success");
            return Ok(await _productRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _productRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            return Created(String.Empty, await _productRepository.CreateAsync(product));
        }

    }
}


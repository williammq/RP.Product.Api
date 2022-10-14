using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RP.Product.Api.data;
using RP.Product.Api.Models;
using RP.Product.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RP.Product.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly AplicationDbContext _db;
        private readonly ProductService productServive;
        public ProductController(AplicationDbContext db)
        {
            _db = db;
            productServive = new ProductService(_db);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Producto>))]
        [ProducesResponseType(400)] //Badrequest
        public async Task<IActionResult> GetProduct()
        {
            try
            {
                var vlRespuesta = await productServive.GetProduct();
                return Ok(vlRespuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}", Name = "GetProductById")]
        [ProducesResponseType(200, Type = typeof(List<Producto>))]
        [ProducesResponseType(400)] //Badrequest
        [ProducesResponseType(404)] //notfound
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var obj = await productServive.GetProductById(id);
                if (obj == null)
                {
                    return NotFound();
                }
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)] // intern error
        public async Task<IActionResult> CreateProduct([FromBody] Producto producto)
        {
            try
            {
                if (producto == null)
                {
                    return BadRequest(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var obj = await productServive.CreateProduct(producto);
                if (obj == null)
                {
                    BadRequest(ModelState);
                }
                return Ok(obj);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
        }
    }
}

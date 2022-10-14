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
    public class BrandController : Controller
    {
        private readonly AplicationDbContext _db;
        private readonly BrandService brandService;
        public BrandController(AplicationDbContext db)
        {
            _db = db;
            brandService = new BrandService(_db);
        }

        [HttpGet]
        [ProducesResponseType(200,Type=typeof(List<Brand>))]
        [ProducesResponseType(400)] //Badrequest
        public async Task<IActionResult> GetBrandAll()
        {
            try
            {
                var vlRespuesta = await brandService.GetAllBrand();
                return Ok(vlRespuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}", Name= "GetBrandById")]
        [ProducesResponseType(200, Type = typeof(List<Brand>))]
        [ProducesResponseType(400)] //Badrequest
        [ProducesResponseType(404)] //notfound
        public async Task<IActionResult> GetBrandById(int id)
        {
            try
            {
                var obj = await brandService.GetBrandById(id);
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
        public async  Task<IActionResult> CreateBrand([FromBody] Brand brand)
        {
            try
            {
                if (brand == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var obj =await brandService.CreateBrand(brand);
            if(obj == null)
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

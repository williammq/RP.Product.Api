using Microsoft.EntityFrameworkCore;
using RP.Product.Api.data;
using RP.Product.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RP.Product.Api.Services
{
    public class ProductService
    {
        private readonly data.AplicationDbContext _db;
        public ProductService(AplicationDbContext db)
        {
            _db = db;
        }

        
        public async Task<List<Producto>> GetProduct()
        {
            try
            {
            var list = await _db.Productos.OrderBy(c => c.Price).Include(p => p.Brand).Include(c => c.ProductCategory).ToListAsync();
            return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<Producto> GetProductById(int id)
        {
            try
            {
                var obj = await _db.Productos.Include(p => p.Brand).Include(c => c.ProductCategory).FirstOrDefaultAsync(c => c.Id == id);
                return obj;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Producto> CreateProduct(Producto producto)
        {
            try
            { 
                await _db.AddAsync(producto);
                await _db.SaveChangesAsync();

            
                var idNew = producto.Id;
                var obj = await GetProductById(idNew);

                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

    }
}

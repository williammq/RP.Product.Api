
using Microsoft.EntityFrameworkCore;
using RP.Product.Api.data;
using RP.Product.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RP.Product.Api.Services
{
    public class BrandService
    {
        private readonly data.AplicationDbContext _db;
        public BrandService(AplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Brand>> GetAllBrand()
        {
            try
            {
                var list = await _db.Brand.OrderBy(c => c.Nombre).ToListAsync();
                return list;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Brand> GetBrandById(int id)
        {
            try
            {
                var obj = await _db.Brand.FirstOrDefaultAsync(c => c.Id == id);
                return obj;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Brand> CreateBrand(Brand brand)
        {
            try { 

                await _db.AddAsync(brand);
                await _db.SaveChangesAsync();
                var idNew = brand.Id;
                var obj = await GetBrandById(idNew);

                return obj;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Grocery.Models
{
    public class SQLRepository : IRootRepository
    {
        private AppDbContext _context;
        private readonly IConfiguration _config;
        public SQLRepository(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        public long GetNewGuid()
        {
            return long.Parse(DateTime.Now.AddYears(-1).Ticks + "9");
        }
        public async Task<IEnumerable<ProductCategory>> GetListOfProductCategories()
        {
            var productCategories = await _context.ProductCategory.ToListAsync();
            return productCategories;
        }
        public async Task<IEnumerable<ProductBrand>> GetListOfProductBrands()
        {
            var productBrands = await _context.ProductBrand.ToListAsync();
            return productBrands;
        }
        public async Task<IEnumerable<UnitsOfMeasurement>> GetListOfUOM()
        {
            var productUOM = await _context.UnitsOfMeasurement.ToListAsync();
            return productUOM;
        }
        public async Task<ProductCategory> GetProductCategoryByID(string id)
        {
            return await _context.ProductCategory.FindAsync(long.Parse(id));
        }
        public async Task<ProductBrand> GetProductBrandByID(string id)
        {
            return await _context.ProductBrand.FindAsync(long.Parse(id));
        }
        public async Task<UnitsOfMeasurement> GetUOMByID(string id)
        {
            return await _context.UnitsOfMeasurement.FindAsync(long.Parse(id));
        }

        public async Task<ProductCategory> AddNewProductCategory(ProductCategory model)
        {
            _context.ProductCategory.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<ProductBrand> AddNewProductBrand(ProductBrand model)
        {
            _context.ProductBrand.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<UnitsOfMeasurement> AddNewUOM(UnitsOfMeasurement model)
        {
            _context.UnitsOfMeasurement.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<ProductCategory> UpdateProductCategory(ProductCategory model)
        {
            var Category = _context.ProductCategory.Add(model);
            Category.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<ProductBrand> UpdateProductBrand(ProductBrand model)
        {
            var Brand = _context.ProductBrand.Add(model);
            Brand.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<UnitsOfMeasurement> UpdateUOM(UnitsOfMeasurement model)
        {
            var UOM = _context.UnitsOfMeasurement.Add(model);
            UOM.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<ProductCategory> DeleteProductCategory(ProductCategory model)
        {
            _context.Remove(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<ProductBrand> DeleteProductBrand(ProductBrand model)
        {
            _context.Remove(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<UnitsOfMeasurement> DeleteUOM(UnitsOfMeasurement model)
        {
            _context.Remove(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}

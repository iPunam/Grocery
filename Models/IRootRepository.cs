using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery.Models
{
    public interface IRootRepository
    {
        long GetNewGuid();
        Task<IEnumerable<ProductCategory>> GetListOfProductCategories();
        Task<IEnumerable<ProductBrand>> GetListOfProductBrands();
        Task<IEnumerable<UnitsOfMeasurement>> GetListOfUOM();
        Task<ProductCategory> GetProductCategoryByID(string id);
        Task<ProductBrand> GetProductBrandByID(string id);
        Task<UnitsOfMeasurement> GetUOMByID(string id);
        Task<ProductCategory> AddNewProductCategory(ProductCategory model);
        Task<ProductBrand> AddNewProductBrand(ProductBrand model);
        Task<UnitsOfMeasurement> AddNewUOM(UnitsOfMeasurement model);
        Task<ProductCategory> UpdateProductCategory(ProductCategory model);
        Task<ProductBrand> UpdateProductBrand(ProductBrand model);
        Task<UnitsOfMeasurement> UpdateUOM(UnitsOfMeasurement model);
        Task<ProductCategory> DeleteProductCategory(ProductCategory model);
        Task<ProductBrand> DeleteProductBrand(ProductBrand model);
        Task<UnitsOfMeasurement> DeleteUOM(UnitsOfMeasurement model);

    }
}

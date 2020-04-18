using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grocery.Models;
using Grocery.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Grocery.Controllers
{
    public class ProductConfigController : BaseController<ProductConfigController>
    {
        [HttpGet]
        public async Task<IActionResult> Index(string Type = "")
        {
            if (!string.IsNullOrEmpty(Type))
            {
                if (Type == ProductConfigType.Product_Category)
                {
                    var model = await RootRepository.GetListOfProductCategories();
                    var productCaterories = Mapper.Map<IEnumerable<ProductConfig>>(model);
                    ViewBag.ConfigType = Type;
                    return View(productCaterories);
                }
                else if (Type == ProductConfigType.Product_Brand)
                {
                    var model = await RootRepository.GetListOfProductBrands();
                    var productBrands = Mapper.Map<IEnumerable<ProductConfig>>(model);
                    ViewBag.ConfigType = Type;
                    return View(productBrands);
                }
                else if (Type == ProductConfigType.Product_UOM)
                {
                    var model = await RootRepository.GetListOfUOM();
                    ViewBag.ConfigType = Type;
                    var productUOMs = Mapper.Map<IEnumerable<ProductConfig>>(model);
                    return View(productUOMs);
                }
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Config(string Type, string id = "")
        {
            ProductConfig productConfig = new ProductConfig();
            if (!string.IsNullOrEmpty(Type))
            {
                if (!string.IsNullOrEmpty(id))
                {
                    if (Type == ProductConfigType.Product_Category)
                    {
                        var model = await RootRepository.GetProductCategoryByID(id);
                        var productCaterory = Mapper.Map<ProductConfig>(model);
                        ViewBag.ConfigType = Type;
                        return View(productCaterory);
                    }
                    else if (Type == ProductConfigType.Product_Brand)
                    {
                        var model = await RootRepository.GetProductBrandByID(id);
                        var productBrand = Mapper.Map<ProductConfig>(model);
                        ViewBag.ConfigType = Type;
                        return View(productBrand);
                    }
                    else if (Type == ProductConfigType.Product_UOM)
                    {
                        var model = await RootRepository.GetUOMByID(id);
                        ViewBag.ConfigType = Type;
                        var productUOM = Mapper.Map<ProductConfig>(model);
                        return View(productUOM);
                    }
                }
                else
                {
                    //productConfig.ID = RootRepository.GetNewGuid();
                    AddTypeToViewBag(Type);
                    return View(productConfig);
                }
            }
            return View(productConfig);
        }

        [HttpPost]
        public async Task<IActionResult> Config(ProductConfig model, string command, string Type)
        {
            if (!string.IsNullOrEmpty(Type))
            {
                if (command == "Save")
                {
                    ValidateData(model, Type);
                    if (ModelState.ErrorCount > 0)
                    {
                        AddTypeToViewBag(Type);
                        return View(model);
                    }
                    if (Type == ProductConfigType.Product_Category)
                    {
                        ProductCategory productCategory = new ProductCategory();
                        if (model.ID == 0)
                        {
                            productCategory = Mapper.Map<ProductCategory>(model);
                            productCategory.ProdCategoryID = RootRepository.GetNewGuid();

                            await RootRepository.AddNewProductCategory(productCategory);
                        }
                        else
                        {
                            productCategory = await RootRepository.GetProductCategoryByID(model.ID.ToString());

                            if (productCategory == null)
                            {
                                ModelState.AddModelError("", $"Product Category with Id = {model.ID} is not found in system.");
                                AddTypeToViewBag(Type);
                                return View(model);
                            }
                            else
                            {
                                productCategory.ProdCategoryName = model.Name;
                                productCategory.ProdCategoryDesc = model.Desc;
                                productCategory.ProdCategoryIndex = model.Index;
                                await RootRepository.UpdateProductCategory(productCategory);
                            }
                        }
                        return RedirectToAction("Config", "ProductConfig", new { Type = Type, id = productCategory.ProdCategoryID });
                    }
                    else if (Type == ProductConfigType.Product_Brand)
                    {
                        ProductBrand productBrand = new ProductBrand();
                        if (model.ID == 0)
                        {
                            productBrand = Mapper.Map<ProductBrand>(model);
                            productBrand.ProdBrandID = RootRepository.GetNewGuid();

                            await RootRepository.AddNewProductBrand(productBrand);
                        }
                        else
                        {
                            productBrand = await RootRepository.GetProductBrandByID(model.ID.ToString());

                            if (productBrand == null)
                            {
                                ModelState.AddModelError("", $"Product Brand with Id = {model.ID} is not found in system.");
                                AddTypeToViewBag(Type);
                                return View(model);
                            }
                            else
                            {
                                productBrand.ProdBrandName = model.Name;
                                productBrand.ProdBrandDesc = model.Desc;
                                productBrand.ProdBrandIndex = model.Index;
                            }
                        }
                        return RedirectToAction("Config", "ProductConfig", new { Type = Type, id = productBrand.ProdBrandID });
                    }
                    else if (Type == ProductConfigType.Product_UOM)
                    {
                        UnitsOfMeasurement unitsOfMeasurement = new UnitsOfMeasurement();
                        if (model.ID == 0)
                        {
                            unitsOfMeasurement = Mapper.Map<UnitsOfMeasurement>(model);
                            unitsOfMeasurement.UOMID = RootRepository.GetNewGuid();

                            await RootRepository.AddNewUOM(unitsOfMeasurement);
                        }
                        else
                        {
                            unitsOfMeasurement = await RootRepository.GetUOMByID(model.ID.ToString());

                            if (unitsOfMeasurement == null)
                            {
                                ModelState.AddModelError("", $"UOM with Id = {model.ID} is not found in system.");
                                AddTypeToViewBag(Type);
                                return View(model);
                            }
                            else
                            {
                                unitsOfMeasurement.UOMName = model.Name;
                                unitsOfMeasurement.UOMDesc = model.Desc;
                                unitsOfMeasurement.UOMIndex = model.Index;
                            }
                        }
                        return RedirectToAction("Config", "ProductConfig", new { Type = Type, id = unitsOfMeasurement.UOMID });
                    }
                }
                else if (command == "Delete")
                {
                    if (Type == ProductConfigType.Product_Category)
                    {
                        ProductCategory productCategory = new ProductCategory();
                        productCategory = await RootRepository.GetProductCategoryByID(model.ID.ToString());

                        if (productCategory == null)
                        {
                            ModelState.AddModelError("", $"Product Category with Id = {model.ID} is not found in system.");
                            AddTypeToViewBag(Type);
                            return View(model);
                        }
                        else
                        {
                            await RootRepository.DeleteProductCategory(productCategory);
                            return RedirectToAction("Index", "ProductConfig", new { Type = Type });
                        }
                    }
                    else if (Type == ProductConfigType.Product_Brand)
                    {
                        ProductBrand productBrand = new ProductBrand();
                        productBrand = await RootRepository.GetProductBrandByID(model.ID.ToString());

                        if (productBrand == null)
                        {
                            ModelState.AddModelError("", $"Product Brand with Id = {model.ID} is not found in system.");
                            AddTypeToViewBag(Type);
                            return View(model);
                        }
                        else
                        {
                            await RootRepository.DeleteProductBrand(productBrand);
                            return RedirectToAction("Index", "ProductConfig", new { Type = Type });
                        }
                    }
                    else if (Type == ProductConfigType.Product_UOM)
                    {
                        UnitsOfMeasurement unitsOfMeasurement = new UnitsOfMeasurement();
                        unitsOfMeasurement = await RootRepository.GetUOMByID(model.ID.ToString());

                        if (unitsOfMeasurement == null)
                        {
                            ModelState.AddModelError("", $"UOM with Id = {model.ID} is not found in system.");
                            AddTypeToViewBag(Type);
                            return View(model);
                        }
                        else
                        {
                            await RootRepository.DeleteUOM(unitsOfMeasurement);
                            return RedirectToAction("Index", "ProductConfig", new { Type = Type });
                        }
                    }
                }
            }
            return View(model);
        }
        private void ValidateData(ProductConfig model, string Type)
        {
            int intNameMaxLength = 0;
            int intDescMaxLength = 0;
            int intIndexMaxLength = 0;
            if (string.IsNullOrEmpty(model.Name))
            {
                ModelState.AddModelError("", Type + " Name can't be blank");
            }

            if (string.IsNullOrEmpty(model.Desc))
            {
                ModelState.AddModelError("", Type + " Description can't be blank");
            }

            if (model.Index == 0)
            {
                ModelState.AddModelError("", Type + " Index can't be zero");
            }

            if (Type == ProductConfigType.Product_Category)
            {
                intNameMaxLength = 30;
                intDescMaxLength = 50;
                intIndexMaxLength = 3;
            }
            else if (Type == ProductConfigType.Product_Brand)
            {
                intNameMaxLength = 50;
                intDescMaxLength = 70;
                intIndexMaxLength = 4;
            }
            else if (Type == ProductConfigType.Product_UOM)
            {
                intNameMaxLength = 10;
                intDescMaxLength = 40;
                intIndexMaxLength = 2;
            }

            if (model.Name.Trim().Length > intNameMaxLength)
            {
                ModelState.AddModelError("", Type + " Name can't be greater than " + intNameMaxLength + " characters");
            }

            if (model.Desc.Trim().Length > intDescMaxLength)
            {
                ModelState.AddModelError("", Type + " Description can't be greater than " + intDescMaxLength + " characters");
            }

            if (model.Index.ToString().Length > intIndexMaxLength)
            {
                ModelState.AddModelError("", Type + " Index can't be greater than " + intIndexMaxLength + " characters");
            }
        }
        private void AddTypeToViewBag(string Type)
        {
            if (Type == ProductConfigType.Product_Category)
            {
                ViewBag.ConfigType = Type;
            }
            else if (Type == ProductConfigType.Product_Brand)
            {
                ViewBag.ConfigType = Type;
            }
            else if (Type == ProductConfigType.Product_UOM)
            {
                ViewBag.ConfigType = Type;
            }
        }
    }
}
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using sample_app.Models;
using sample_app.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Controllers
{
    // Browser : /home/index

    public class HomeController : Controller
    {
        private readonly IStoreRepository _repository;
        private readonly ILogger<HomeController> _logger;
        private readonly IFileProvider _fileProvider;
        private readonly IMapper _mapper;
        public int PageSize = 2;
        public HomeController(IStoreRepository repository,
            ILogger<HomeController> logger,
            IFileProvider fileProvider, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _fileProvider = fileProvider;
            _mapper = mapper;
        }
        // Action Methods
        public IActionResult Index(string category, int productPage = 1)
        {
            _logger.LogInformation($"Index Action Called {category} for {productPage}");
            var products = _repository.Products
            .Where(p => category == null || p.Category == category)
              .OrderBy(p => p.ProductID)
              .Skip((productPage - 1) * PageSize)
              .Take(PageSize);
            var PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = category == null ? _repository.Products.Count() :
                _repository.Products.Where(e => e.Category == category).Count()
            };
            var productListViewModel = new ProductListViewModel
            {
                Products = products,
                PagingInfo = PagingInfo,
                CurrentCategory = category
            };

            _logger.LogInformation($"ProductListViewModel Object Created");
            // Will give me the products
            return View(productListViewModel); // Passed a fetched products to View
        }
        // Present the Form
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductEditModel productEditModel) // Model binding
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation($"ModelState is valid");
                // Convert ProductEditModel to Product
                var product = _mapper.Map<Product>(productEditModel);
                _repository.AddProduct(product);
                return RedirectToAction("Index");
            }

            _logger.LogError($"ModelState is Invalid for Create Action");
            return View();
        }

        // This Will Return View That display detailed information about the product
        public IActionResult Details(int id)
        {
            var product = _repository.GetProduct(id);
            return View(product); // Pass Product to view
        }

        //  Action To Delete a Product
        public IActionResult Delete(int id)
        {
            _repository.DeleteProduct(id);
            return RedirectToAction("Index");
        }

        // Action to Present Form to the User with Specific Product information

        public IActionResult Update(int id)
        {
            var product = _repository.GetProduct(id);
            var productEditModel = _mapper.Map<ProductEditModel>(product);
            return View(productEditModel);
        }
        [HttpPost]
        public IActionResult Update(ProductEditModel productEditModel)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation($"ModelState is valid for Update Action");
                var product = _mapper.Map<Product>(productEditModel);
                _repository.UpdateProduct(product.ProductID, product);
                return RedirectToAction("Index");
            }

            _logger.LogError($"ModelState is Invalid for Update Action");

            return View();

        }

        public IActionResult AboutUs()
        {
            //throw new Exception();
            return View();
        }
        public IActionResult Contact()
        {
            var contents = _fileProvider.GetDirectoryContents("KYC");
            return View(contents);
        }

        [HttpPost("FileUpload")]
        public async Task<IActionResult> FileUpload(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            var filePaths = new List<string>();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "KYC", formFile.FileName);

                    filePaths.Add(path);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            // process uploaded files
            // Don't rely on or trust the FileName property without validation.
            return Ok(new { count = files.Count, size, filePaths });
        }


        // Validation Logic for Checking whether Category Entered is Valid or not
        public IActionResult VerifyCategory(string category)
        {
            // Category :   Cricket /Chess /Soccer
            if (!CheckCategory(category))
            {
                // Issue
                return Json($"Only Cricket /Chess /Soccer Allowed");
            }
            return Json(true); // Successs
        }
        public bool CheckCategory(string category)
        {
            if (category == "Cricket" || category == "Chess" || category == "Soccer")
            {
                return true;
            }
            return false;
        }

        public IActionResult PerformTransaction()
        {
            try
            {
                _repository.PerformTransaction();
                return Content("Transaction Successful");
            }
            catch (Exception)
            {
                return Content("Transaction Failed");
            }
            
        }

    }
}

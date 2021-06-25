using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sample_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly IStoreRepository _repository;
        private readonly ILogger<NavigationMenuViewComponent> _logger;

        // IStoreRepo :  Get the Uniquee CAtegories

        public NavigationMenuViewComponent(IStoreRepository repository,ILogger<NavigationMenuViewComponent> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public IViewComponentResult Invoke()
        {
            // Set the infromation related to Current Selected Category
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            _logger.LogInformation($"Category Selected : {ViewBag.SelectedCategory}");

            var uniqueCategories = _repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            // Generate View That can show the uniqueCategorie
            return View(uniqueCategories);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using sample_app.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.ViewModels
{
    public class ProductAddModel
    {


        [Required(ErrorMessage = "Name is Required Field")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is Required Field")]
        [StringLength(20, ErrorMessage = "{0} Length Must be between  {2} {1}", MinimumLength = 5)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is Required Field")]
        [Range(0, 9999)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Category is Required Field")]
        [Remote(action: "VerifyCategory", controller: "Home")]
        public string Category { get; set; }

        [Required(ErrorMessage = "MfgDate is Required Field")]
        [Display(Name = "Mfg Date")]
        [ValidMfgDate ]
        public DateTime MfgDate { get; set; }

    }
}

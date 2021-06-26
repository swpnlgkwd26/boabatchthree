using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Models
{
    public class Sale
    {
        [Key]
        public int ProductID { get; set; }

        public string  ProductName { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Models
{
    public class BankOfAmericaBatchThreeContext :DbContext
    {
        public BankOfAmericaBatchThreeContext(DbContextOptions<BankOfAmericaBatchThreeContext> options):base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}

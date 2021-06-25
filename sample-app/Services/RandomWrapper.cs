using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Services
{
    public class RandomWrapper : IRandomWrapper
    {
        private readonly IRandomService _randomService;
        // Resolved
        public RandomWrapper(IRandomService randomService)
        {
            _randomService = randomService;
        }
        public int GetNumber()
        {
            return _randomService.GetNumber();
        }
    }
}

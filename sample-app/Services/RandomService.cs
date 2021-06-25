using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Services
{

    // Returns  a Random Number
    public class RandomService : IRandomService
    {
        private int _randomNumber;
        public RandomService()
        {
            Random random = new Random();
            _randomNumber = random.Next(10000);
        }
        public int GetNumber()
        {
            return _randomNumber;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameML
{
    public class RandomSnakeController : ISnakeController
    {
        private Random _rand = new Random();

        public Steering MakeMove(SteeringInput input)
        {
            return (Steering)_rand.Next(0, 3);
        }
    }
}

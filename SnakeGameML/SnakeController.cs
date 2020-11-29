using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameML
{
    public enum Steering
    {
        stay = 0,
        right = 1,
        left = 2
    }

    public interface ISnakeController
    {
        Steering MakeMove();
    }


    public class RandomSnakeController : ISnakeController
    {
        private Random _rand = new Random();

        public Steering MakeMove()
        {
            return (Steering)_rand.Next(0, 3);
        }
    }
}

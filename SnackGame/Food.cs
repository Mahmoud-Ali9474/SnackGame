using System;

namespace SnakeGame
{
    class Food
    {
        public Point p;
        int max;
        private readonly Random _random = new Random();
        public Food(int max)
        {
            p = new Point(10, 10);
            this.max = max;   
        }

       public void GenerateNewPoint()
        {
            p.x = _random.Next(1,max);
            p.y = _random.Next(1,max);
        }
    }
}

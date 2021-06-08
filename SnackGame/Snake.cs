using System;
using System.Collections.Generic;

namespace SnakeGame
{
    enum direction
    {
        UpArrow = 1, DownArrow = 3, LeftArrow = 2, RightArrow = 4
    }
    class Snake
    {
        public List<Point> snake;
        direction dir;
        public Snake()
        {
            Point p = new Point(5, 5);
            Point p1 = new Point(5, 4);
            snake = new List<Point>() { p, p1 };
            dir = direction.RightArrow;
        }
        public void Add()
        {
            int idx = snake.Count-1;
            Point p = new Point(snake[idx].x, snake[idx].y);
            snake.Add(p);
        }
        public void Move()
        {
            int i = (int)dir;
            i = GetKey(i);
            dir = (direction)i;
            int x = 0, y = 0;
            switch (i)
            {
                case 1:
                        x = -1; y = 0;
                    break;
                case 2:
                        x = 0; y = -1;
                    break;
                case 3:
                        x = 1; y = 0;
                    break;
                case 4:
                        x = 0; y = 1;
                    break;

            }
            Update(snake[0].x + x, snake[0].y + y);
        
        }

        private int GetKey(int i)
        {
            if (Console.KeyAvailable)
            {
                direction d;
                if (Enum.TryParse(Console.ReadKey(true).Key.ToString(), out d))
                {
                    int j = (int)d;
                    if (Math.Abs(j - i) != 2)
                        i = j;
                }
            }

            return i;
        }

        public void Update(int x,int y)
        {
            for(int i = 0; i < snake.Count; i++)
            {
                Swap(ref snake[i].x,ref x);
                Swap(ref snake[i].y,ref y);
              
            }
        }

        private static void Swap(ref int y1, ref int y2)
        {
            int t = y1;
            y1 = y2;
            y2 = t;
        }
    }
}

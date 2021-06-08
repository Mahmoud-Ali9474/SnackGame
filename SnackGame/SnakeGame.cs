using System;
using System.Threading;

namespace SnakeGame
{
    enum BordWidth
    {
        easy=22,medium=18,hard=16
    }
    class SnakeGame
    {
        Snake s;
        Food f;
        Score score;
        int max;
        int Speed;
        string Mode;
        int PointsForOneFood;
        public SnakeGame(int speed)
        {
            
            Speed = GetSpeed(speed);
            BordWidth b;
            Enum.TryParse(Mode,out b);
            max = (int)b;
            f = new Food(max);
            s = new Snake();
            score = new Score();

        }
        public bool GameOver()
        {
            if (s.snake[0].x == 0 || s.snake[0].x == max || s.snake[0].y == 0 || s.snake[0].y == max)
                return true;
            for(int i = 1; i < s.snake.Count; i++)
            {
                if (s.snake[i].Equals(s.snake[0]))
                    return true;
            }
            return false;
        }
        public bool Contains(int x,int y)
        {
            foreach (Point p in s.snake)
            {
                if (p.x == x && p.y == y)
                {
                    return true;
                }

            }

            return false;
        }
        public void show()
        {
            for(int i = 0; i <= max; i++)
            {
                bool x = false;
                for(int j = 0; j <= max; j++)
                {
                    if (i == 0 || i == max || j == 0 || j == max)
                        Console.Write("█");
                    else if(Contains(i,j))
                        Console.Write("■");

                    else if (i == f.p.x && j == f.p.y)
                        Console.Write("O");
                    else if(!x)
                        Console.Write(" ");
                }
                if (i > 3 && i <= 5)
                {
                    PrintScore(i);
                }
                Console.WriteLine();
            }
            
        }

        private void PrintScore(int i)
        {
            if(i==4)
                Console.Write($"      Your High Score is {score.HighScore}");
            else
                Console.Write($"      Your Score is {score.CurrentScore}");

        }

        public  void Display()
        {

            while (!GameOver())
            {
                show();
                s.Move();
                if (s.snake[0].Equals(f.p))
                {
                    score.CurrentScore +=PointsForOneFood ;
                    f.GenerateNewPoint();
                    s.Add();
                }
                Thread.Sleep(Speed);
                Console.Clear();
            }
            Console.WriteLine();
            if (score.CurrentScore > score.HighScore)
            {
                score.PutHighScore();
                Console.WriteLine($"Congratution! You Achieve New Score {score.CurrentScore}");
            }
            else
                Console.WriteLine($"Your Score is Score {score.CurrentScore}");
            Console.WriteLine("        Game Over!");
        }

        private int GetSpeed(int Speed)
        {
            if (Speed == 2)
            {
                Speed = 150;
                Mode = "medium";
                PointsForOneFood = 7;
            }
            else if (Speed == 3)
            {
                Speed = 200;
                Mode = "easy";
                PointsForOneFood = 5;

            }
            else
            {
                Speed = 100;
                Mode = "hard";
                PointsForOneFood = 10;

            }
            return Speed;
        }
    }
}

using System;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string str = "";
            do
            {
                int speed=GetMode();
                SnakeGame s = new SnakeGame(speed);
                s.Display();
                Console.WriteLine("Do You Want to Play Again (Y/N)");
                str = Console.ReadLine().ToLower();
            } while (str == "y" || str == "yes");
            
            
        }

        private static int GetMode()
        {
            bool RightMode = false;
            int x;
            do
            {
                Console.WriteLine("Please Play Mode ");
                Console.WriteLine("-For Easy Press   1");
                Console.WriteLine("-For Medium Press 2");
                Console.WriteLine("-For Hard Press   3");
                RightMode=int.TryParse(Console.ReadLine(), out x);
                Console.Clear();
            } while (!RightMode||x==0||x>3);
            return x;

        }
    }
}

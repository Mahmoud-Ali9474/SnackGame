using System.Text;

namespace SnakeGame
{
    public class Point
    {
       public int x;
       public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            Point p = (Point)obj;
            return x == p.x && y == p.y;
        }

        public override int GetHashCode()
        {
            string s = $"{y}{this.x}";
            byte[]arr = Encoding.ASCII.GetBytes(s);
            int x = 0;
            x +=arr[0]*10 ;
            x += arr[1];
            return x;
        }
    }
}

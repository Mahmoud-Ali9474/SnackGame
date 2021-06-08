using System.IO;
namespace SnakeGame
{
    class Score
    {
       public int HighScore;
       public int CurrentScore;

        public Score()
        {
            GetHighScore();
            CurrentScore = 0;
        }

        public void GetHighScore()
        {
            using (var reader = File.OpenText("text.txt"))
            {
                HighScore = int.Parse(reader.ReadLine());
            } 

            
        }
        public void PutHighScore()
        {
            File.Delete("text.txt");
            using(var writer=File.AppendText("text.txt"))
            {
                writer.WriteLine(CurrentScore.ToString());
            }

        }
    }
}

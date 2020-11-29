using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SnakeGameML
{
    public class InputRow
    {
        public double ObstacleOnRight;
        public double ObstacleOnLeft;
        public double ObstacleOnFront;
        public double SuggestedDirection;
        public bool StillAlive;
        public int score;
    }


    public class TrainingDataCollector
    {
        private string _fileLocation;

        public TrainingDataCollector(string fileLocation)
        {
            _fileLocation = fileLocation;
        }

        public void SaveRow(InputRow inputRow)
        {
            using (StreamWriter sw = File.AppendText(_fileLocation))
            {
                sw.Write($"{inputRow.ObstacleOnRight}\t");
                sw.Write($"{inputRow.ObstacleOnLeft}\t");
                sw.Write($"{inputRow.ObstacleOnFront}\t");
                sw.Write($"{inputRow.SuggestedDirection}\t");
                sw.Write($"{inputRow.StillAlive}\t");
                sw.Write($"{inputRow.score}\n");
            }
        }

    }
}

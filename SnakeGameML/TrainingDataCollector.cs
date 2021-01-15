using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SnakeGameML
{

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
                sw.Write($"{inputRow.ObstacleOnLeft:F1}\t"); // 1 yes, 0 no
                sw.Write($"{inputRow.ObstacleOnFront:F1}\t"); //1, 0
                sw.Write($"{inputRow.ObstacleOnRight:F1}\t");// 1, 0 
                sw.Write($"{inputRow.SuggestedDirection:F1}\t"); // -1 left, 0 - forward, 1 -right , 0, 1
                sw.Write($"{inputRow.NormalizedAngle:F3}\t"); // -1 to  1
                sw.Write($"{inputRow.Decision:F1}\n"); // -1 killed, 0 wrong dir, 1 ok dir
                //sw.Write($"{inputRow.score}\n");
            }
        }

    }
}
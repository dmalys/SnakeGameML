using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SnakeGameML
{
    public class PredictionController : ISnakeController
    {


        public Steering MakeMove(SteeringInput input)
        {
            // TODO: send data in json as double
            var right = input.obstacleOnRight;
            var front = input.obstacleOnFront;
            var left = input.obstacleOnLeft;
            var angle = input.angle;
            //var distance = input.distance;
            //var score = input.score;

            var front_weight = MakeCall(right, front, left, 0.0, angle);//, distance, score); //right, front, left, 0.0, angle);
            var right_weight = MakeCall(right, front, left, 1.0, angle);//, distance, score);
            var left_weight = MakeCall(right, front, left, -1.0, angle);//, distance, score);

            var results = new[]
            {
                (Steering.stay, front_weight),
                (Steering.right, right_weight),
                (Steering.left, left_weight)
            };

            var resultsSorted = results.OrderByDescending(x => x.Item2)
                .ToArray();

            ////To prevent stuck in a circle we need z bit of randomness
            //if (Math.Abs(resultsSorted[0].Item2 - resultsSorted[1].Item2) < 0.01)
            //{
            //    var r = new Random();
            //    var number = r.Next(0, 1000);
            //    if (number > 600)
            //    {
            //        if (resultsSorted[0].Item1 == Steering.stay) return resultsSorted[1].Item1;
            //        else return resultsSorted[0].Item1;
            //    }
            //    else
            //    {
            //        return Steering.stay;
            //    }
            //}

            return resultsSorted[0].Item1;
        }

        private double MakeCall(double right, double front, double left, double dir, double angle)//double dir, double angle, double distance, int score)//double right, double front, double left, double dir, double angle)
        {
            var html = string.Empty;

            var url = $"http://127.0.0.1:5000";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";

            var jsonContent = new JObject();
            jsonContent.Add("right", new JValue(right));
            jsonContent.Add("front", new JValue(front));
            jsonContent.Add("left", new JValue(left));
            jsonContent.Add("dir", new JValue(dir));
            jsonContent.Add("angle", new JValue(angle));
            //jsonContent.Add("distance", new JValue(distance));
            //jsonContent.Add("score", new JValue(score));
            var content = Encoding.UTF8.GetBytes(jsonContent.ToString());

            using (var reqStream = request.GetRequestStream())
            {
                reqStream.Write(content, 0, content.Length);
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            var json = JObject.Parse(html);
            var array1 = json.GetValue("result") as JArray;
            var array2 = array1[0] as JArray;
            var value = array2[0] as JValue;
            return double.Parse(value.ToString());
        }
    }
}

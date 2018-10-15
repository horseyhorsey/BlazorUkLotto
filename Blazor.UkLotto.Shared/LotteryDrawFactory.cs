using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Blazor.UkLotto.Shared
{
    public class LotteryDrawFactory
    {
        private static List<string> DrawLines { get; set; }

        public LotteryDrawFactory()
        {

        }

        public IEnumerable<LotteryDraw> GetDrawHistory()
        {
            if (DrawLines == null)
                DeserializeDrawHistory();

            var lotteryDraws = new List<LotteryDraw>();
            DrawLines.Reverse();

            int drawNumber = 1;
            foreach (var line in DrawLines)
            {
                //Split on , 10 times, rest of the data we don't need for this.
                var newLine = line.Split(new char[1]{ ','}, count:11);

                //Create draw from split csv
                var lottoDraw = new LotteryDraw()
                {
                    Number = drawNumber,
                    Date = DateTime.Parse(newLine[0]),
                    Balls = new LotteryBall[6]
                    {
                        new LotteryBall() { Number = Convert.ToByte(newLine[1])},
                        new LotteryBall() { Number = Convert.ToByte(newLine[2])},
                        new LotteryBall() { Number = Convert.ToByte(newLine[3])},
                        new LotteryBall() { Number = Convert.ToByte(newLine[4])},
                        new LotteryBall() { Number = Convert.ToByte(newLine[5])},
                        new LotteryBall() { Number = Convert.ToByte(newLine[6])},
                    },
                    BonusBall = new LotteryBall() { Number = Convert.ToByte(newLine[7]) },
                    MachineName = newLine[9]

                };

                //Order the balls, lo - hi and add to list
                lottoDraw.Balls = lottoDraw.Balls.OrderBy(x => x.Number).ToArray();
                lotteryDraws.Add(lottoDraw);

                drawNumber++;
            }

            lotteryDraws.Reverse();
            return lotteryDraws;
        }

        List<string> DeserializeDrawHistory()
        {
            var assembly = Assembly.GetExecutingAssembly();
            Stream resource = assembly
                .GetManifestResourceStream("Blazor.UkLotto.Shared.lotto-draw-history.csv");
            using (StreamReader reader = new StreamReader(resource))
            {
                var lines = new List<string>();
                while (!reader.EndOfStream)
                {
                    lines.Add(reader.ReadLine());
                }

                //Read all lines from Csv
                DrawLines = lines;
            }

            //Remove header line
            DrawLines.RemoveAt(0);

            return DrawLines;
        }
    }
}

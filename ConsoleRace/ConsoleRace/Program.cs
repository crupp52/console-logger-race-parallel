using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRace
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Logger> loggers = new List<Logger>()
            {
                new Logger(ConsoleColor.Blue),
                new Logger(ConsoleColor.Yellow),
                new Logger(ConsoleColor.Green),
                new Logger(ConsoleColor.Red)
            };

            Task[] tasks = new Task[loggers.Count];

            for (int i = 0; i < tasks.Length; i++)
            {
                int j = i;
                tasks[j] = new Task(() =>
                {
                    while (!loggers[j].Vege)
                    {
                        loggers[j].Lep();
                    }
                });

                tasks[j].Start();
            }

            Task.WaitAll(tasks);
        }
    }
}

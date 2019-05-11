using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleRace
{
    class Logger
    {
        public static object _lock = new object();
        static int globalID = 0;
        static Random rnd = new Random();

        public int Tavolsag { get; private set; }
        public int SorID { get; set; }
        public ConsoleColor Color { get; set; }
        public bool Vege { get { return Tavolsag == 100; } }

        public Logger(ConsoleColor color)
        {
            this.Tavolsag = 0;
            this.SorID = globalID += 2;
            this.Color = color;
        }

        int Szamol()
        {
            return rnd.Next(0, 10);
        }

        public void Lep()
        {
            Thread.Sleep(rnd.Next(50, 300));
            lock (_lock)
            {
                Console.SetCursorPosition(this.Tavolsag, this.SorID);
                Console.ForegroundColor = this.Color;
                Console.Write(Szamol());
                this.Tavolsag++;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG_Csharp.TextRPG2
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            while (true)
            {
                game.Process();
            }
        }
    }
}

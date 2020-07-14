using System;

namespace textPVE
{
    class Program
    {
        static void Main(string[] args)
        {
            Process game = new Process();
            while(true)
            {
                game.process();
            }
        }
    }
}

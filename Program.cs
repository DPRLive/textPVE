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
                bool exit = false;
                game.process(ref exit);
                if(exit == true)
                    break;
            }
        }
    }
}
using System;

namespace textPVE
{
    enum ProcessMode
    {
        None,
        Selcet = 1,
        lobby = 2,
        Town = 3
    }

    class Process
    {
        protected ProcessMode _mode = ProcessMode.Selcet;
        private ProcessMode _type = ProcessMode.None;
        private Monster monster = null; 
        private Player player = null;

        public void setGameMode(ProcessMode mode) { _mode = mode; }
        public void process()
        {
            switch (mode)
            {
                case ProcessMode.Selcet:
                    processSelect();
                    break;
                case ProcessMode.lobby:
                    processLobby();
                    break;
                case ProcessMode.Town:
                    processTown();
                    break;
            }
        }

        public void processSelect()
        {
            Console.WriteLine("*************************");
            Console.WriteLine("캐릭터를 선택하세요.");
            Console.WriteLine("[1] 기사 [2] 도적 [3] 마법사");
            Console.WriteLine("*************************");

            string input = console.ReadLine();

            switch (input)
            {
                case "1":
                    player = new Kight();
                    break;
                case "2":
                    player = new Thief();
                    break;
                case "3":
                    player = new Mage();
                    break;
            }
        }

    }
}
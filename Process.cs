using System;

namespace textPVE
{
    enum ProcessMode
    {
        None,
        Selcet = 1,
        Lobby = 2,
        Hunt = 3,
        Exit = 4
    }

    enum AttackType
    {
        None,
        Normal = 1,
        Skill = 2,
    }

    class Process
    {
        private ProcessMode _mode = ProcessMode.Selcet;
        private Monster monster = null; 
        private Player player = null;
        Random rand = new Random();

        public void setGameMode(ProcessMode mode) { _mode = mode; }
        public void process()
        {
            switch (_mode)
            {
                case ProcessMode.Selcet:
                    processSelect();
                    break;
                case ProcessMode.Lobby:
                    processLobby();
                    break;
                case ProcessMode.Hunt:
                    processHunt();
                    break;
                case ProcessMode.Exit:
                    break;
            }
        }

        public void processSelect()
        {
            Console.WriteLine("*************************");
            Console.WriteLine("캐릭터를 선택하세요.");
            Console.WriteLine("[1] 기사 [2] 도적 [3] 마법사"); 
            Console.WriteLine("*************************");

            string input = Console.ReadLine();

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
            setGameMode(ProcessMode.Lobby);
        }

        public void processLobby()
        {
            player.getInfo();
            Console.WriteLine("1. 몬스터 사냥");
            Console.WriteLine("2. 캐릭터 선택");
            Console.WriteLine("3. 게임 종료");
            Console.WriteLine("*************************");
            
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    setGameMode(ProcessMode.Hunt);
                    processHunt();
                    break;
                case "2":
                    setGameMode(ProcessMode.Selcet);
                    break;
                case "3":
                    setGameMode(ProcessMode.Exit);
                    break;
            }
        }

        public void processHunt()
        {
            createNewMonster();
            player.getInfo();
            Console.WriteLine("1. 기본 공격");
            Console.WriteLine("2. 스킬 사용");
            Console.WriteLine("3. 로비로 돌아가기");
            Console.WriteLine("*************************");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    processFight(AttackType.Normal);
                    break;
                case "2":
                    processFight(AttackType.Skill);
                    break;
                case "3":
                    setGameMode(ProcessMode.Lobby);
                    break;        
            }
        }

        public void processFight(AttackType aType)
        {
            while(true)
            {
                bool dead = false;
                if(aType == AttackType.Normal)
                    processDamage(player.getAttack(), monster.getAttack(), ref dead);
                else if(aType == AttackType.Skill)
                    processDamage(player.skillShot(), monster.getAttack(), ref dead);
                if(dead)
                    break;
            }
        }
        
        public void processDamage(int PlayerDamage, int MonsterDamage, ref bool dead)
        {
            monster.onDamage(PlayerDamage);
            if(monster.isDead())
            {
                Console.WriteLine("몬스터를 잡았습니다!");
                Creature.upKillCount();
                dead = true;
            }

            player.onDamage(MonsterDamage);
            if(player.isDead())
            {
                Console.WriteLine("사망했습니다!");
                dead = true;
            }
        }

        public void createNewMonster()
        {
            int mtype = rand.Next(1,4);

            switch (mtype)
                {
                    case 1:
                        Console.WriteLine("**슬라임이 생성 되었습니다.**");
                        monster = new Slime();
                        break;

                    case 2:
                        Console.WriteLine("**골렘이 생성 되었습니다.**");
                        monster = new Golem();
                        break;
                    case 3:
                        Console.WriteLine("**좀비가 생성 되었습니다.**");
                        monster = new Zombie();
                        break;      
                }
        }
    }
}
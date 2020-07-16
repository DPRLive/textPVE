using System;

namespace textPVE
{
    enum PlayerType
        {
            None,
            Kight = 1,
            Thief = 2,
            Mage = 3
        }

    class Player : Creature
    {
        public Random rand = new Random();

        private int _mp = 0;
        private int _UseMp = 0;
        private PlayerType _type = PlayerType.None;
        
        protected Player(PlayerType type) : base(CreatureType.Player) { _type = type; }

        public void setMp(int mp) { _mp = mp; }
        public void setUseMp(int UseMp) { _UseMp = UseMp; }

        public int getMp() { return _mp; }
        public int getUseMp() { return _UseMp; }

        public override void getInfo() 
        {
            Console.WriteLine("*************************");
            Console.WriteLine("현재 직업: {0} ", getClassType());
            Console.WriteLine($"현재 체력: {getHp()}");
            Console.WriteLine($"현재 마나: {getMp()}");
            Console.WriteLine($"잡은 몬스터 수: {getKillCount()}");
            Console.WriteLine("*************************");
        }

        private string getClassType()
        {
            switch(_type){
                case PlayerType.Kight:
                    return "기사";
                case PlayerType.Thief:
                    return "도적";
                case PlayerType.Mage:
                    return "마법사";
                default:
                    return "현재 선택된 직업이 없습니다.";
            }
        }

        public virtual int skillShot()
        {
            Console.WriteLine(getClassType(), ", 스킬사용!");
            _mp -= getUseMp();
            return 0;
        }

    }

    class Kight : Player
    {
        public Kight() : base(PlayerType.Kight)
        {
            setHp(120);
            setMp(50);
            setAttack(10); 
            setUseMp(7);
        }

        public override int skillShot()
        {
            base.skillShot();
            return rand.Next(20,30);
        }
    }

    class Thief : Player
    {
        public Thief() : base(PlayerType.Thief)
        {
            setHp(100);
            setMp(75);
            setAttack(15); 
            setUseMp(10);
        } 

        public override int skillShot()
        {
            base.skillShot();
            return rand.Next(20,46);
        }
    }

    class Mage : Player
    {
        public Mage() : base(PlayerType.Mage)
        {
            setHp(80);
            setMp(100);
            setAttack(20); 
            setUseMp(13);
        } 

        public override int skillShot()
        {
            base.skillShot();
            return rand.Next(25,56);
        }
    }
}
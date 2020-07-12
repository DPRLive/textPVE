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
        private PlayerType _type = PlayerType.None;
        
        protected Player(PlayerType type) : base(CreatureType.Player) { _type = type; }

        public void setMp(int mp) { _mp = mp; }

        public int getMp() { return _mp; }

        public void getInfo() 
        {
            Console.WriteLine("*************************");
            Console.WriteLine("현재 직업: ", getClassType(_type));
            Console.WriteLine($"현재 체력: {getHp()}");
            Console.WriteLine($"현재 마나: {getMp()}");
            //Console.WriteLine($"잡은 몬스터 수: {count}");
            Console.WriteLine("*************************");
        }

        private string getClassType(PlayerType type)
        {
            switch(type){
                case PlayerType.Kight:
                    return "기사";
                    break;
                case PlayerType.Thief:
                    return "도적";
                    break;
                case PlayerType.Mage:
                    return "마법사";
                    break;        
            }
        }

        public virtual int skillShot(int mp)
        {
            Console.WriteLine(getClassType(), ", 스킬사용!");
            _mp -= mp;
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
        }

        public override int skillShot(int mp)
        {
            base.skillShot(5);
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
        } 

        public override int skillShot(int mp)
        {
            base.skillShot(7);
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
        } 

        public override int skillShot(int mp)
        {
            base.skillShot(10);
            return rand.Next(25,56);
        }
    }
}
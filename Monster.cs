using System;

namespace textPVE
{
    enum MonsterType
        {
            None,
            Slime = 1,
            Golem = 2,
            Zombie = 3
        }

    class Monster : Creature
    {
        private MonsterType _type = MonsterType.None;
        protected Monster(MonsterType type) : base(CreatureType.Monster) { _type = type;}
     
        private string getMonsterType()
        {
            switch(_type){
                case MonsterType.Slime:
                    return "슬라임";
                case MonsterType.Golem:
                    return "골렘";
                case MonsterType.Zombie:
                    return "좀비";
                default:
                    return "현재 생성된 몬스터가 없습니다.";
            }
        }

        public override void getInfo() 
        {
            Console.WriteLine("현재 몬스터: {0} ", getMonsterType());
            Console.WriteLine($"현재 몬스터 체력: {getHp()}");
            Console.WriteLine("*************************");
        }
    }

    class Slime : Monster
    {
        public Slime() : base(MonsterType.Slime)
        {
            setHp(20);
            setAttack(5); 
        } 
    }

    class Golem : Monster
    {
        public Golem() : base(MonsterType.Golem)
        {
            setHp(40);
            setAttack(10); 
        } 
    }

    class Zombie : Monster
    {
        public Zombie() : base(MonsterType.Zombie)
        {
            setHp(55);
            setAttack(8); 
        } 
    }
}
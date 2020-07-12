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
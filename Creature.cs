namespace textPVE
{
    enum CreatureType
    {
        None,
        Player = 1,
        Monster = 2
    }

    class Creature
    {
        private int _hp = 0;
        private int _attack = 0;
        private CreatureType _type = CreatureType.None;
        static int KillCount = 0;

        protected Creature(CreatureType type) { _type = type; }

        public void setHp(int hp) { _hp = hp; }
        public void setAttack(int attack) { _attack = attack; }

        public int getHp() {  return _hp; }
        public int getAttack() { return _attack; }

        public static void upKillCount(){ KillCount++; }
        public static int getKillCount(){ return KillCount; }

        public bool isDead()
        {
            if (_hp <= 0)
                return true;
            else
                return false;
        }

        public void onDamage(int damage)
        {
            _hp -= damage;
            if(_hp < 0)
                _hp = 0;
        }
    }
}
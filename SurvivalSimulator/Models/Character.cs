namespace SurvivalSimulator.Models
{
    public abstract class Character
    {
        public string Name { get; }
        public int HP { get; private set; }
        public int AttackPower { get; }

        protected Character(string name, int hp, int attackPower)
        {
            Name = name;
            HP = hp;
            AttackPower = attackPower;
        }
        public virtual void Attack(Character target)
        {
            target.TakeDamage(AttackPower);
        }
        public void TakeDamage(int damage)
        {
            HP -= damage;
            if (HP < 0) HP = 0;
        }
        public bool IsAlive => HP > 0;
    }

}

namespace SurvivalSimulator.Models
{
	public class Enemy : Character
	{
		public int Distance { get; }
		public Enemy(string name, int hp, int attackPower, int distance)
			: base(name, hp, attackPower)
		{
			Distance = distance;
		}

	}
}

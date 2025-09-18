using SurvivalSimulator.Models;

public class BattleSimulation
{
	private Hero _hero;
	private int _resourceDistance;
	private readonly List<Enemy> _enemies = new List<Enemy>();

	public BattleSimulation SetResourceDistance(int distance)
	{
		_resourceDistance = distance;
		return this;
	}

	public BattleSimulation AddHero(string name, int hp, int attack)
	{
		_hero = new Hero(name, hp, attack);
		return this;
	}

	public BattleSimulation AddEnemy(string name, int hp, int attack, int distance)
	{
		_enemies.Add(new Enemy(name, hp, attack, distance));
		return this;
	}

	public void Start()
	{
		Console.WriteLine($"Kaynaklar {_resourceDistance} metre uzaklıkta.");
		Console.WriteLine($"Kahraman {_hero.HP} HP ile başladı!\n");

		_enemies.Sort((a, b) => a.Distance.CompareTo(b.Distance));

		foreach (var enemy in _enemies)
		{
			Console.WriteLine($"{enemy.Distance}. metrede bir {enemy.Name} var.");

			while (_hero.IsAlive && enemy.IsAlive)
			{
				_hero.Attack(enemy);
				enemy.Attack(_hero);
			}

			if (!_hero.IsAlive)
			{
				Console.WriteLine($"\n{enemy.Name}, kahramanı {enemy.Distance}. metrede öldürdü!");
				Console.WriteLine($"Kalan {enemy.Name} HP: {Math.Max(enemy.HP, 0)}");
				Console.WriteLine("Kahraman öldü! Kaynağa ulaşılamadı.");
				return;
			}
			else
			{
				Console.WriteLine($"Kahraman, {enemy.Name}i {_hero.HP} HP ile yendi!");
			}
		}

		Console.WriteLine($"\nKahraman hayatta kaldı ve {_resourceDistance} metredeki kaynaklara ulaştı!");
	}
}


class Program
{
	static void Main(string[] args)
	{
		new BattleSimulation()
			.SetResourceDistance(5000)
			.AddHero("Kahraman", 1000, 10)
			.AddEnemy("Böcek", 50, 2, 276)
			.AddEnemy("Böcek", 50, 2, 489)
			.AddEnemy("Aslan", 100, 15, 1527)
			.AddEnemy("Aslan", 100, 15, 2865)
			.AddEnemy("Zombi", 300, 7, 3523)
			.AddEnemy("Zombi", 300, 7, 1681)
			.Start();
	}
}

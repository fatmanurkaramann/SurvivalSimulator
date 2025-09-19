using SurvivalSimulator.Models;

public class BattleSimulation
{
	private Hero _hero;
	private int _resourceDistance;
	private readonly List<Enemy> _enemies = new();

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

		FightEnemies();

		if (_hero.IsAlive)
		{
			Console.WriteLine($"\nKahraman hayatta kaldı ve {_resourceDistance} metredeki kaynaklara ulaştı!");
		}
	}
	private void FightEnemies(int index = 0)
	{
		if (index >= _enemies.Count) return;

		var enemy = _enemies[index];
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
			Console.WriteLine($"Kahraman, {enemy.Name}’i {_hero.HP} HP ile yendi!");
		}
		FightEnemies(index + 1);
	}

}
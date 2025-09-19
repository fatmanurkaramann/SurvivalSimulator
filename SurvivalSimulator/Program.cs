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

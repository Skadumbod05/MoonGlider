using Godot;
using System;

public partial class Spawner : Node2D
{
	private PackedScene asteroidScene = GD.Load<PackedScene>("res://asteroid_1.tscn"); // Load the asteroid scene
	private Godot.Timer _spawnTimer;   
	[Export] private float baseSpawnTime1 = 1.0f;
	[Export] private float MinimumSpawnTime = 0.16f;
	private float timeElapsed = 0.0f;
	public override void _Ready()
	{
		_spawnTimer = GetNode<Godot.Timer>("SpawnTimer");
		_spawnTimer.Timeout += OnSpawnTimerTimeout1;    // Connect the timeout signal to the OnSpawnTimerTimeout method

		_spawnTimer2 = GetNode<Godot.Timer>("SpawnTimer2");
		_spawnTimer2.Timeout += OnSpawnTimerTimeout2;
	}

	public override void _Process(double delta)
	{
		timeElapsed += (float)delta;
		float calculatedTime = baseSpawnTime1 / (1.0f + (timeElapsed * 0.06f));
		_spawnTimer.WaitTime = Mathf.Max(MinimumSpawnTime, calculatedTime);  
		
		float calculatedTime2 = baseSpawnTime2 / (1.0f + (timeElapsed * 0.15f));
		_spawnTimer2.WaitTime = Mathf.Max(MinimumSpawnTime, calculatedTime2);      // Pick the larger num as waitime. Minimumspawn is safe gaurd so doesnt spawn too quick
	}
	private void Spawnasteroid1(float MinXPosition, float MaxXPosition)
	{
		var asteroidInstance = (Node2D)asteroidScene.Instantiate();                                                
		AddChild(asteroidInstance);                                                 
		var posX = (float)GD.RandRange(MinXPosition, MaxXPosition);                 // Randomize the X position of the asteroid
		asteroidInstance.Position = new Vector2(posX, -50); 
	}
	private void OnSpawnTimerTimeout1()
	{
		Spawnasteroid1(0.0f, 1152.0f); // Call the SpawnAsteroid method with the desired X position range
	}





	private PackedScene asteroidScene2 = GD.Load<PackedScene>("res://asteroid_2.tscn"); // Load the asteroid scene

	private Godot.Timer _spawnTimer2;
	[Export] private float baseSpawnTime2 = 2.0f;
	private void OnSpawnTimerTimeout2()
	{
		Spawnasteroid2(0.0f, 1152.0f);
	}

	private void Spawnasteroid2(float MinXPosition2, float MaxXPosition2)
	{
		var asteroidInstance2 = (Node2D)asteroidScene2.Instantiate();                                                
		AddChild(asteroidInstance2);                                                 
		var posX = (float)GD.RandRange(MinXPosition2, MaxXPosition2);                 // Randomize the X position of the asteroid
		asteroidInstance2.Position = new Vector2(posX, -50);
	}

	
}

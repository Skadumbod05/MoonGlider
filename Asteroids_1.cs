using Godot;
using System;

public partial class Asteroids_1 : Area2D
{

	// Called when the node enters the scene tree for the first time.

	private float MinYSpeed = 180.0f;
	private float MaxYSpeed = 380.0f;
	private float MinXSpeed = -90.0f;
	private float MaxXSpeed = 90.0f;

	private float MinScale = 0.8f;
	private float MaxScale = 1.2f;



	private Vector2 velocity = new Vector2();

	private float gravity = 410.0f;

	public override void _Ready()
	{
		velocity.Y = (float)GD.RandRange(MinYSpeed, MaxYSpeed);
		velocity.X = (float)GD.RandRange(MinXSpeed, MaxXSpeed);
		float RandomScale = (float)GD.RandRange(MinScale, MaxScale);
		Scale = new Vector2(RandomScale, RandomScale);

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		velocity.Y += gravity * (float)delta;
		Position += velocity * (float)delta;

		//Remove asteroid when it goes too low.
		if (Position.Y > 550)
		{
			this.QueueFree();
			var variableManager = GetTree().GetFirstNodeInGroup("VariableManager") as Variable_manager;
			variableManager.AddScore(1);
		
		}
	}


//Returns DamageTaken to update HEALTH	
	public int Score = 0;
public void _on_area_entered(Area2D area)
	{
		GD.Print("Hit by node: " + area.Name);
		if (area.IsInGroup("AstronautHurtbox"))
		{
			var variableManager = GetTree().GetFirstNodeInGroup("VariableManager") as Variable_manager;
			if (variableManager != null)
			{
				variableManager.DamageTaken(1);
				GD.Print("sentback damage taken 1");
			}
		}
	}

}

using Godot;
using System;

public partial class Astronaut : CharacterBody2D
{

	public float Speed = 315.0f;
	public float jump_speed = 400.0f;
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		
		float gravity = 420.0f;
		velocity.Y += gravity * (float)delta;

		if(Input.IsActionJustPressed("ui_up") && IsOnFloor())
		{
			velocity.Y = -jump_speed;
		}

		if (Input.IsActionPressed("ui_right"))
		{
			velocity.X = Speed;
		}
		else if (Input.IsActionPressed("ui_left"))
		{
			velocity.X = -Speed;
		}
		else
		{
			velocity.X = 0;
		}

		Velocity = velocity;
		MoveAndSlide();

	}

	public override void _Process(double delta)
	{

	}
	

}

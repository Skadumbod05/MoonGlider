using Godot;
using System;

public partial class HealthBox : HBoxContainer
{
	public void HealthUI()
	{
		GD.Print("HealthUI called");
		var variableManager = GetTree().GetFirstNodeInGroup("VariableManager") as Variable_manager;
		int currentHealth = variableManager.HitPoints;
		GD.Print("Current Health: " + currentHealth);
		if (currentHealth == 3)
		{
			GetNode<TextureRect>("%Heart_1").Visible = true;
			GetNode<TextureRect>("%Heart_2").Visible = true;
			GetNode<TextureRect>("%Heart_3").Visible = true;
		}
		else if (currentHealth == 2)
		{
			GetNode<TextureRect>("%Heart_1").Visible = true;
			GetNode<TextureRect>("%Heart_2").Visible = true;
			GetNode<TextureRect>("%Heart_3").Visible = false;
		}
		else if (currentHealth == 1)
		{
			GetNode<TextureRect>("%Heart_1").Visible = true;
			GetNode<TextureRect>("%Heart_2").Visible = false;
			GetNode<TextureRect>("%Heart_3").Visible = false;
		}
		else if (currentHealth <= 0)
		{
			GetNode<TextureRect>("%Heart_1").Visible = false;
			GetNode<TextureRect>("%Heart_2").Visible = false;
			GetNode<TextureRect>("%Heart_3").Visible = false;
		}
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

using Godot;
using System;
using System.Collections;

public partial class DeathScreen : CanvasLayer
{

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("DeathScreen Ready");

		var variableManager = GetTree().GetFirstNodeInGroup("VariableManager") as Variable_manager;
		if (variableManager == null)
		{
			GD.Print("Variable_manager not found in the scene tree.");
			return;
		}

		var scoreDisplay = GetNode<Label>("%ScoreLabel");
		scoreDisplay.Text = $"Score: {variableManager.Score}";

		if (scoreDisplay == null)
		{
			GD.Print("ScoreLabel not found in the DeathScreen scene.");
		}
	}

	private void _on_retry_button_pressed()
	{
		GD.Print("The button got clicked");
		GetTree().Paused = false;
		GetTree().ReloadCurrentScene();
		RemoveDeathScreen();
	}

	private void RemoveDeathScreen()
	{
		GD.Print("Inside Remove DeathScreen mwthod");
		this.QueueFree();  
	}
	public override void _Process(double delta)
	{
	}
}
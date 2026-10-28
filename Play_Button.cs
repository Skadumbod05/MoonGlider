using Godot;
using System;

public partial class MainMenu : Control
{
	private void _on_play_button_pressed()
	{
		GD.Print("Play button pressed");
		GetTree().ChangeSceneToFile("res://Scenes/main_game.tscn");
		GD.Print("Play button pressed");
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("In _Ready() method");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

using Godot;
using System;
public PackedScene simultaneousScene ;



public class CardGame : Node2D
{
	public MyClass()
{
	simultaneousScene = (PackedScene)ResourceLoader.Load("res://Assets/Karte/Monster_01.tscn").instance();
}

public void _AddASceneManually()
{
	// This is like autoloading the scene, only
	// it happens after already loading the main scene.
	GetTree().GetRoot().AddChild(simultaneousScene);
}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		 // This is like autoloading the scene, only
		// it happens after already loading the main scene.
		_AddASceneManually();
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}

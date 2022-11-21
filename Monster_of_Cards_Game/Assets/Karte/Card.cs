using Godot;
using Godot.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;

public class Card : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	private Texture[] myTextures;
	private List<String> myTextureList = new List<String>();

	public override void _Ready()
	{
		myTextureList.Add("res://Assets/Monsters/Monster_01.png");
		myTextureList.Add("res://Assets/Monsters/Monster_02.png")
		myTextureList.Add("res://Assets/Monsters/Monster_03.png")
		myTextureList.Add("res://Assets/Monsters/Monster_04.png")
		myTextureList.Add("res://Assets/Monsters/Monster_05.png")
			
		//GD.Print(myTextureList);
		GD.Randomize();

	
		var texture = ImageTexture.new()
		var image = Image.new()
		image.load(GetCard())
		texture.create_from_image(image)
		$Sprite.texture = texture
		

		//var texture = (Texture)GD.Load("res://Assets/Monsters/Monster_02.png"); // resource is loaded when line is executed
		GD.Print(myTextureList[0]);


	}

	public string GetCard()
	{
		string randomCard = _cards[GD.Randi() % myTextureList.Length];
		// Returns "apple", "orange", "pear", or "banana" every time the code runs.
		// We may get the same fruit multiple times in a row.
		return randomCard;
	}

	//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	//  public override void _Process(float delta)
	//  {
	//      
	//  }
}

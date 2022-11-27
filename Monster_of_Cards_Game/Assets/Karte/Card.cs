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
	private List<string> myTextureList = new List<string>();
	
	
	

	public override void _Ready()
	{
		myTextureList.Add("res://Assets/Monsters/Monster_01.png");
		myTextureList.Add("res://Assets/Monsters/Monster_02.png");
		myTextureList.Add("res://Assets/Monsters/Monster_03.png");
		myTextureList.Add("res://Assets/Monsters/Monster_04.png");
		myTextureList.Add("res://Assets/Monsters/Monster_05.png");
		myTextureList.Add("res://Assets/Monsters/Monster_06.png");
			
		//GD.Print(myTextureList);
		GD.Randomize();
		//Sprite cardSprite = (Sprite)GetNode("Card_Sprite");
		//cardSprite.SetTextur("res://Assets/Monsters/Monster_02.png")
		Random random = new Random();
		int index = random.Next(myTextureList.Count);
		Godot.Sprite cartSprite =  this.GetNode<Godot.Sprite>("Card_Sprite");
		
		

		//var texture = (Texture)GD.Load("res://Assets/Monsters/Monster_02.png"); // resource is loaded when line is executed
		GD.Print(myTextureList[index]);


	}


	//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	//  public override void _Process(float delta)
	//  {
	//      
	//  }
}

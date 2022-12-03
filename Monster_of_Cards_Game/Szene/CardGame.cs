using Godot;
using Godot.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;




public class CardGame : Node2D
{
	private List<string> myTextureList = new List<string>();
	public PackedScene simultaneousScene ;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		myTextureList.Add("res://Assets/Karte/Monster_01.tscn");
		myTextureList.Add("res://Assets/Karte/Monster_02.tscn");
		myTextureList.Add("res://Assets/Karte/Monster_03.tscn");
		myTextureList.Add("res://Assets/Karte/Monster_04.tscn");
		myTextureList.Add("res://Assets/Karte/Card.tscn");
		
		
		GD.Randomize();
		Random random = new Random();
		GD.Print(random);
		
		for(int i = 0; i <3; i++){
			int index = random.Next(myTextureList.Count);
			GD.Print("Hi: ",index);
			//simultaneousScene = (PackedScene)GD.Load(myTextureList[index]);
			simultaneousScene = (PackedScene)GD.Load(myTextureList[4]);
			var test = simultaneousScene.Instance();
			var zahl = test.GetPositionInParent();
			GD.Print("HI: ",zahl);
			AddChild(test);
			
		
			
			
			//test.Translation= Vector2(10*i, 10*i);
		}
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}

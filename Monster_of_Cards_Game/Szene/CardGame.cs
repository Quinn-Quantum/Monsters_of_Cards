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

	private Monster_01_2D  _Monster01;
	private Monster_02_2D  _Monster02;

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

	
		_Monster01 = GetNode<Monster_01_2D>("Monster_01");
		_Monster01.SetGlobalPosition(new Vector2(100,200));
		_Monster02 = GetNode<Monster_02_2D>("Monster_02_2D");
		_Monster02.SetGlobalPosition(new Vector2(300,200));
		
		
		
		for(int i = 0; i <3; i++){
			int index = random.Next(myTextureList.Count);
			GD.Print("Hi: ",index);
			
			
		
			
			
			//test.Translation= Vector2(10*i, 10*i);
		}
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
     if(Input.IsActionJustPressed("draw")){
		GD.Print("Draw");

	 }
  }
}

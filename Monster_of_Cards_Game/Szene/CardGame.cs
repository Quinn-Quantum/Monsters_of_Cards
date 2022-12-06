using Godot;
using Godot.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;




public class CardGame : Node2D
{

	
	private List<Monster_01_2D> myCardList = new List<Monster_01_2D>();
	public PackedScene simultaneousScene ;

	private Monster_01_2D  _Monster01;
	private Monster_01_2D  _Monster02;

	

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		
		_Monster01 = GetNode<Monster_01_2D>("Monster_01");
		_Monster01.SetGlobalPosition(new Vector2(100,200));
		_Monster01._SetImage("res://Assets/Monsters/Monster_04.png");
		
		_Monster02 = GetNode<Monster_01_2D>("Monster_02");
		_Monster02.SetGlobalPosition(new Vector2(300,100));
		_Monster02._SetImage("res://Assets/Monsters/Monster_09.png");

		

		myCardList.Add(_Monster01);
		myCardList.Add(_Monster02);
		
		
		
		
			
			
		
			
			
			//test.Translation= Vector2(10*i, 10*i);
		}
		// Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
     if(Input.IsActionJustPressed("draw")){
		GD.Print("Draw");
		GD.Randomize();
		Random random = new Random();
		for(int i = 0; i <1; i++){
			int index = random.Next(myCardList.Count);
			var move = myCardList[index];
			move.SetGlobalPosition(new Vector2(500,500));
			
			GD.Print("Hi: ",index);



	 }
  }
  }

		
	}
  

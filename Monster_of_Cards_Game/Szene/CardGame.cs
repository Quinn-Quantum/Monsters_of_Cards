using Godot;
using Godot.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;




public class CardGame : Node2D
{

	//All Cards
	
	public PackedScene simultaneousScene ;

	private Monster_01_2D  _Monster01;
	private Monster_01_2D  _Monster02;
	private Monster_01_2D  _Monster03;
	private Monster_01_2D  _Monster04;
	private Monster_01_2D  _Monster05;
	private Monster_01_2D  _Monster06;
	private Monster_01_2D  _Monster07;
	private Monster_01_2D  _Monster08;
	private Monster_01_2D  _Monster09;
	private Monster_01_2D  _Monster10;
	private Monster_01_2D  _Monster11;
	private Monster_01_2D  _Monster12;
	private Monster_01_2D  _Monster13;

	private int activePlayer = 1;
	private int nextPlayer = 2;

	private Button _EndTurnButton;
	private Button _StartTurnButton;

	//Für Spieler eins
	private List<Monster_01_2D> myCardList = new List<Monster_01_2D>();

	private List<Monster_01_2D> playerOneHand = new List<Monster_01_2D>();
	private deck_number number_cards_in_deck;

	private bool firstDraw = true;
	//Hand Positionen
	private List<Vector2> hand1_pos = new List<Vector2>();
	
	//für Spieler zwei
	private Vector2 hand2;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		hand1_pos.Add(new Vector2(200,490));
		hand1_pos.Add(new Vector2(300,490));
		hand1_pos.Add(new Vector2(400,490));
		hand1_pos.Add(new Vector2(500,490));
		hand1_pos.Add(new Vector2(600,490));
		hand1_pos.Add(new Vector2(700,490));
		//Zeilen für Karten
		//Spieler 2 Handkarten	y=100
		//Spieler 2 Feld		y=230
		//Spieler 1 Feld		y=360
		//Spieler 1 Handkarten	y=490
		
		
		_Monster01 = GetNode<Monster_01_2D>("Monster_01");
		_Monster01._SetImage("res://Assets/Monsters/Monster_01.png");
		
		_Monster02 = GetNode<Monster_01_2D>("Monster_02");
		_Monster02._SetImage("res://Assets/Monsters/Monster_02.png");

		_Monster03 = GetNode<Monster_01_2D>("Monster_03");
		_Monster03._SetImage("res://Assets/Monsters/Monster_03.png");

		_Monster04 = GetNode<Monster_01_2D>("Monster_04");
		_Monster04._SetImage("res://Assets/Monsters/Monster_04.png");

		_Monster05 = GetNode<Monster_01_2D>("Monster_05");
		_Monster05._SetImage("res://Assets/Monsters/Monster_05.png");

		_Monster06 = GetNode<Monster_01_2D>("Monster_06");
		_Monster06._SetImage("res://Assets/Monsters/Monster_06.png");

		_Monster07 = GetNode<Monster_01_2D>("Monster_07");
		_Monster07._SetImage("res://Assets/Monsters/Monster_07.png");

		_Monster08 = GetNode<Monster_01_2D>("Monster_08");
		_Monster08._SetImage("res://Assets/Monsters/Monster_08.png");

		_Monster09 = GetNode<Monster_01_2D>("Monster_09");
		_Monster09._SetImage("res://Assets/Monsters/Monster_09.png");

		_Monster10 = GetNode<Monster_01_2D>("Monster_10");
		_Monster10._SetImage("res://Assets/Monsters/Monster_10.png");

		_Monster11 = GetNode<Monster_01_2D>("Monster_11");
		_Monster11._SetImage("res://Assets/Monsters/Monster_11.png");

		_Monster12 = GetNode<Monster_01_2D>("Monster_12");
		_Monster12._SetImage("res://Assets/Monsters/Monster_12.png");

		_Monster13 = GetNode<Monster_01_2D>("Monster_13");
		_Monster13._SetImage("res://Assets/Monsters/Monster_13.png");

		myCardList.Add(_Monster01);
		myCardList.Add(_Monster02);
		myCardList.Add(_Monster03);
		myCardList.Add(_Monster04);
		myCardList.Add(_Monster05);
		myCardList.Add(_Monster06);
		myCardList.Add(_Monster07);
		myCardList.Add(_Monster08);
		myCardList.Add(_Monster09);
		myCardList.Add(_Monster10);
		myCardList.Add(_Monster11);
		myCardList.Add(_Monster12);
		myCardList.Add(_Monster13);


		number_cards_in_deck = GetNode<deck_number>("Card_back/deck_number");
		number_cards_in_deck.SetText(myCardList.Count.ToString()+" Cards");
		
		_EndTurnButton = GetNode<Button>("EndTurnButton");
		_StartTurnButton = GetNode<Button>("StartTurnButton");
			
			//test.Translation= Vector2(10*i, 10*i);
		}
		// Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {

	
     if(Input.IsActionJustPressed("draw")){
		GD.Randomize();
		Random random = new Random();
		if(firstDraw){
			for(int i = 0; i <=4; i++){
			int index = random.Next(myCardList.Count);
			var move = myCardList[index];
			playerOneHand.Add(move);
			move.SetVisible(true);
			myCardList.RemoveAt(index);
			number_cards_in_deck.SetText(myCardList.Count.ToString()+" Cards");
			
			}
			firstDraw = false;
		}
		else{
			int index_n = random.Next(myCardList.Count);
			var move = myCardList[index_n];
			move.SetVisible(true);
			
			myCardList.RemoveAt(index_n);
			playerOneHand.Add(move);
			number_cards_in_deck.SetText(myCardList.Count.ToString()+" Cards");
		}
		
			for(int k=0; k<playerOneHand.Count; k++){

				var card = playerOneHand[k];
				card.SetGlobalPosition(hand1_pos[k]);
  			}

  }
  
 	 
  }

  private void _on_EndTurnButton_pressed() {
	foreach (var item in playerOneHand)
	{
		item.SetVisible(false);
	}
	_StartTurnButton.SetVisible(true);
	_EndTurnButton.SetVisible(false);
  }

  private void _on_StartTurnButton_pressed() {

  }

}
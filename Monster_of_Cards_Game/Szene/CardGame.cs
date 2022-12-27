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

	private bool startDraw=false;

	//for player one
	private List<Monster_01_2D> myCardList = new List<Monster_01_2D>();

	private List<Monster_01_2D> playerOneHand = new List<Monster_01_2D>();
	private Monster_01_2D choose_card;
	private deck_number number_cards_in_deck;

	private bool firstDrawPlayerOne = true;
	//Hand Positionen
	private List<Vector2> hand1_pos = new List<Vector2>();
	private bool cardhighlighted = false;
	private int pos ;
	private int max_pos;
	private int min_pos = 0;
	//Feld Player one
	private List<Vector2> field1_pos = new List<Vector2>();
	int fill_number=0;
	private bool fild1full=false;
	private  List<Monster_01_2D> card_fild1 = new List<Monster_01_2D>();
	
	//for player two
	private Vector2 hand2;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		
		//Hand Positionen Player one
		hand1_pos.Add(new Vector2(60,400));
		hand1_pos.Add(new Vector2(160,400));
		hand1_pos.Add(new Vector2(260,400));
		hand1_pos.Add(new Vector2(360,400));
		hand1_pos.Add(new Vector2(460,400));
		hand1_pos.Add(new Vector2(560,400));
		//Feld Positionen Player one
		field1_pos.Add(new Vector2(100,200));
		field1_pos.Add(new Vector2(260,200));
		field1_pos.Add(new Vector2(420,200));
		
		
		//Dec Player one

		_Monster01 = crateCard("Monster_01","res://Assets/Monsters/Monster_01.png",3,3, "Test","Hallo Welt");
		
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

		//
		number_cards_in_deck = GetNode<deck_number>("deck_number");
		number_cards_in_deck.SetText(myCardList.Count.ToString()+" Cards");
		
		}
		// Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {

	
     if(Input.IsActionJustPressed("draw")){
		GD.Randomize();
		Random random = new Random();
		if(firstDrawPlayerOne){
			for(int i = 0; i <=4; i++){
			int index = random.Next(myCardList.Count);
			var move = myCardList[index];
			playerOneHand.Add(move);
			move.SetVisible(true);
			myCardList.RemoveAt(index);
			number_cards_in_deck.SetText(myCardList.Count.ToString()+" Cards");
			
			}
			firstDrawPlayerOne = false;
		}
		else if(startDraw){
			int index_n = random.Next(myCardList.Count);
			var move = myCardList[index_n];
			move.SetVisible(true);
			
			myCardList.RemoveAt(index_n);
			playerOneHand.Add(move);
			number_cards_in_deck.SetText(myCardList.Count.ToString()+" Cards");

			startDraw=!startDraw;
		}
		
			sortHandCards();

  }
  //Haver card
  max_pos = playerOneHand.Count;
  if(!cardhighlighted){
	if(Input.IsActionJustPressed("Active")){
			pos = 0;
			choose_card = playerOneHand[pos];
			GD.Print(choose_card.GetScale());

			choose_card.SetGlobalScale(new Vector2(2,2));
			choose_card.SetZIndex(1);
			cardhighlighted = true;
	}

	

  }

	else if(cardhighlighted){
		
		if(Input.IsActionJustPressed("go_right")){
		choose_card = playerOneHand[pos];
			if(pos < max_pos -1){
				

				choose_card.SetGlobalScale(new Vector2(1,1));
				choose_card.SetZIndex(0);

				pos = pos +1;
				choose_card = playerOneHand[pos];
				choose_card.SetGlobalScale(new Vector2(2,2));
				choose_card.SetZIndex(1);

			}
			else{

				choose_card.SetGlobalScale(new Vector2(1,1));
				choose_card.SetZIndex(0);

				pos=0;
				choose_card = playerOneHand[pos];
				choose_card.SetGlobalScale(new Vector2(2,2));
				choose_card.SetZIndex(1);

			}

		}
		if(Input.IsActionJustPressed("go_left")){
			choose_card = playerOneHand[pos];
			if(pos > min_pos){

				choose_card.SetGlobalScale(new Vector2(1,1));
				choose_card.SetZIndex(0);

				pos = pos -1;
				choose_card = playerOneHand[pos];
				choose_card.SetGlobalScale(new Vector2(2,2));
				choose_card.SetZIndex(1);

			}else{

				choose_card.SetGlobalScale(new Vector2(1,1));
				choose_card.SetZIndex(0);

				pos= max_pos -1;
				choose_card = playerOneHand[pos];
				choose_card.SetGlobalScale(new Vector2(2,2));
				choose_card.SetZIndex(1);

			}
	}

//play a card
		if(!fild1full){
			
			if(Input.IsActionJustPressed("Active")){
				choose_card.SetZIndex(0);
				choose_card.SetGlobalScale(new Vector2(1,1));
				choose_card.SetGlobalPosition(field1_pos[fill_number]);
				card_fild1.Add(choose_card);
				playerOneHand.Remove(choose_card);

				sortHandCards();

				if(fill_number <2){
					fill_number ++;
				}
				else{
					fild1full=true;
				}
				
			}

		}

	}
  
 	 
  }

  public void sortHandCards(){

	for(int k=0; k<playerOneHand.Count; k++){

				var card = playerOneHand[k];
				card.SetGlobalPosition(hand1_pos[k]);
  			}

  }

  public Monster_01_2D crateCard(String cardId, String imagePath, int atk, int def,String name, String disciption ){
	Monster_01_2D card= GetNode<Monster_01_2D>(cardId);
	card._SetImage(imagePath);
	card._SetAtk(atk);
	card._SetDef(def);
	card._SetName(name);
	card._SetDescription(disciption);
	return card;

  }
		
	}
  

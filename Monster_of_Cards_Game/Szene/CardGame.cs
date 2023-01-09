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

	private Vector2 _scaler= new Vector2(0.2f,0.2f);
	private Vector2 _scalerBig = new Vector2(0.4f,0.4f);
	private Random random;
//Bool for Ablauf
	private bool firsRound = true;
	private bool drawCard = false;
	private bool playCardTime = false;
	private bool cardhighlighted = false;

	private bool battelTime = false;



	//for player one
	private bool playerOne = true; //if it is Player one turne
	private bool firstDrawPlayerOne = true;
	private List<Monster_01_2D> myCardList1 = new List<Monster_01_2D>();
	private List<Monster_01_2D> playerOneHand = new List<Monster_01_2D>();
	private Monster_01_2D choose_card;
	private deck_number number_cards_in_deck1;

	//Hand Positionen
	private List<Vector2> hand1_pos = new List<Vector2>();
	private int pos;
	private int max_pos;
	private int min_pos = 0;

	//Feld Player one
	private List<Vector2> field1_pos = new List<Vector2>();
	int fill_number=0;
	private bool fild1full=false;
	private  List<Monster_01_2D> card_fild1 = new List<Monster_01_2D>();



	//for player two
	private bool playerTwo = false; //if it is Player one turne
	private bool firstDrawPlayerTwo = true;
	private List<Monster_01_2D> myCardList2 = new List<Monster_01_2D>();
	private List<Monster_01_2D> playerTwoHand = new List<Monster_01_2D>();
	private deck_number number_cards_in_deck2;

	private List<Vector2> hand2_pos = new List<Vector2>();




	private Button _EndTurnButton;
	private Button _StartTurnButton;



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

		//ToDo
		hand2_pos.Add(new Vector2(200,100));
		hand2_pos.Add(new Vector2(300,100));
		hand2_pos.Add(new Vector2(400,100));
		hand2_pos.Add(new Vector2(500,100));
		hand2_pos.Add(new Vector2(600,100));
		hand2_pos.Add(new Vector2(700,100));
		
		
		_Monster01 = crateCard("Monster_01","res://Assets/Monsters/Monster_01.png",3,3, "Test","Hallo Welt");
		_Monster02 = crateCard("Monster_02","res://Assets/Monsters/Monster_02.png",3,3, "Name","Hallo Welt");
		_Monster03 = crateCard("Monster_03","res://Assets/Monsters/Monster_03.png",3,3, "Name","Hallo Welt, was Geht so ab?");
		_Monster04 = crateCard("Monster_04","res://Assets/Monsters/Monster_04.png",3,3, "Name","Hallo Welt, Ich bin ein böses Monster der Unterwelt");
		_Monster05 = crateCard("Monster_05","res://Assets/Monsters/Monster_05.png",3,3, "Name","Hallo Welt, Ich bin ein böses Monster der Unterwelt");
		_Monster06 = crateCard("Monster_06","res://Assets/Monsters/Monster_06.png",3,3, "Name","Hallo Welt, Ich bin ein böses Monster der Unterwelt");
		_Monster07 = crateCard("Monster_07","res://Assets/Monsters/Monster_07.png",3,3, "Name","Hallo Welt, Ich bin ein böses Monster der Unterwelt");
		_Monster08 = crateCard("Monster_08","res://Assets/Monsters/Monster_08.png",3,3, "Name","Hallo Welt, Ich bin ein böses Monster der Unterwelt");
		_Monster09 = crateCard("Monster_09","res://Assets/Monsters/Monster_09.png",3,3, "Name","Hallo Welt, Ich bin ein böses Monster der Unterwelt");
		_Monster10 = crateCard("Monster_10","res://Assets/Monsters/Monster_10.png",3,3, "Name","Hallo Welt, Ich bin ein böses Monster der Unterwelt");
		_Monster11 = crateCard("Monster_11","res://Assets/Monsters/Monster_11.png",3,3, "Name","Hallo Welt, Ich bin ein böses Monster der Unterwelt");
		_Monster12 = crateCard("Monster_12","res://Assets/Monsters/Monster_12.png",3,3, "Name","Hallo Welt, Ich bin ein böses Monster der Unterwelt");
		_Monster13 = crateCard("Monster_13","res://Assets/Monsters/Monster_13.png",3,3, "Name","Hallo Welt, Ich bin ein böses Monster der Unterwelt");

		myCardList1.Add(_Monster01);
		myCardList1.Add(_Monster02);
		myCardList1.Add(_Monster03);
		myCardList1.Add(_Monster04);
		myCardList1.Add(_Monster05);
		myCardList1.Add(_Monster06);
		myCardList1.Add(_Monster07);
		myCardList1.Add(_Monster08);
		myCardList1.Add(_Monster09);
		myCardList1.Add(_Monster10);
		myCardList1.Add(_Monster11);
		myCardList1.Add(_Monster12);
		myCardList1.Add(_Monster13);

		myCardList2.Add(_Monster01);
		myCardList2.Add(_Monster02);
		myCardList2.Add(_Monster03);
		myCardList2.Add(_Monster04);
		myCardList2.Add(_Monster05);
		myCardList2.Add(_Monster06);
		myCardList2.Add(_Monster07);
		myCardList2.Add(_Monster08);
		myCardList2.Add(_Monster09);
		myCardList2.Add(_Monster10);
		myCardList2.Add(_Monster11);
		myCardList2.Add(_Monster12);
		myCardList2.Add(_Monster13);


		number_cards_in_deck1 = GetNode<deck_number>("Card_back/deck_number1");
		number_cards_in_deck1.SetText(myCardList1.Count.ToString()+" Cards");

		number_cards_in_deck2 = GetNode<deck_number>("Card_back2/deck_number2");
		number_cards_in_deck2.SetText(myCardList2.Count.ToString()+" Cards");
		
		_EndTurnButton = GetNode<Button>("EndTurnButton");
		_StartTurnButton = GetNode<Button>("StartTurnButton");

		GD.Randomize();
		random = new Random();
			
			//test.Translation= Vector2(10*i, 10*i);
		}
		// Called every frame. 'delta' is the elapsed time since the previous frame.

  public override void _Process(float delta)
  {

	
	 if(Input.IsActionJustPressed("draw")){			
			//erster zug
			if(firstDrawPlayerOne || firstDrawPlayerTwo){				
					if(playerOne && firstDrawPlayerOne){
						for(int i = 0; i <=4; i++){
							GD.Print("halo i bims");
							int index = random.Next(myCardList1.Count);
							GD.Print("halo i bims2");
							var move = myCardList1[index];
							GD.Print("halo i bims3");
							playerOneHand.Add(move);
							GD.Print("halo i bims4");
							move.SetVisible(true);
							GD.Print("halo i bims5");
							myCardList1.RemoveAt(index);
							GD.Print("halo i bims6");
							number_cards_in_deck1.SetText(myCardList1.Count.ToString()+" Cards");
							GD.Print("halo i bims7");
						}
						firstDrawPlayerOne = false;
						sortHandCards();
						playCardTime=true;

					}
					else if(playerTwo && firstDrawPlayerTwo){
						//Umschreiben für Speiler zwei
						/*for(int i = 0; i <=4; i++){
							int index = random.Next(myCardList.Count);
							var move = myCardList[index];
							playerOneHand.Add(move);
							move.SetVisible(true);
							myCardList.RemoveAt(index);
							number_cards_in_deck.SetText(myCardList.Count.ToString()+" Cards");
						
						}*/
						firstDrawPlayerTwo = false;
						sortHandCards();
						playCardTime=true;

					}
					else{
						GD.Print("Falsche Taste");
					}
				}

			//alleweiteren Züge
			else if(!playCardTime){
				if(playerOne && drawCard){
					int index_n = random.Next(myCardList1.Count);
					var move = myCardList1[index_n];
					move.SetVisible(true);
					
					myCardList1.RemoveAt(index_n);
					playerOneHand.Add(move);
					number_cards_in_deck1.SetText(myCardList1.Count.ToString()+" Cards");

					drawCard=!drawCard;
					sortHandCards();
					playCardTime=true;

				}
				else if (playerTwo && drawCard){

					int index_n = random.Next(myCardList1.Count);
					var move = myCardList1[index_n];
					move.SetVisible(true);
					
					myCardList1.RemoveAt(index_n);
					playerOneHand.Add(move);
					number_cards_in_deck1.SetText(myCardList1.Count.ToString()+" Cards");

					drawCard=!drawCard;
					sortHandCards();
					playCardTime=true;
			
				}
				else{
					GD.Print("Falsche Taste2");
				}
			}
		else{
			GD.Print("kannst nicht ziehen");
		}
	}

	//Haver card
	max_pos = playerOneHand.Count;
	if(!cardhighlighted && playCardTime){
	if(Input.IsActionJustPressed("Active")){
			pos = 0;
			choose_card = playerOneHand[pos];
			GD.Print(choose_card.GetScale());

			choose_card.SetGlobalScale(_scalerBig);
			choose_card.SetZIndex(1);
			cardhighlighted = true;
	}

	}

	else if(cardhighlighted && playCardTime ){
		
		if(Input.IsActionJustPressed("go_right") ){
		choose_card = playerOneHand[pos];
			if(pos < max_pos -1){
				

				choose_card.SetGlobalScale(_scaler);
				choose_card.SetZIndex(0);

				pos = pos +1;
				choose_card = playerOneHand[pos];
				choose_card.SetGlobalScale(_scalerBig);
				choose_card.SetZIndex(1);

			}
			else{

				choose_card.SetGlobalScale(_scaler);
				choose_card.SetZIndex(0);

				pos=0;
				choose_card = playerOneHand[pos];
				choose_card.SetGlobalScale(_scalerBig);
				choose_card.SetZIndex(1);

			}

		}
		if(Input.IsActionJustPressed("go_left")){
			choose_card = playerOneHand[pos];
			if(pos > min_pos){

				choose_card.SetGlobalScale(_scaler);
				choose_card.SetZIndex(0);

				pos = pos -1;
				choose_card = playerOneHand[pos];
				choose_card.SetGlobalScale(_scalerBig);
				choose_card.SetZIndex(1);

			}else{

				choose_card.SetGlobalScale(_scaler);
				choose_card.SetZIndex(0);

				pos= max_pos -1;
				choose_card = playerOneHand[pos];
				choose_card.SetGlobalScale(_scalerBig);
				choose_card.SetZIndex(1);

			}
	}

	//play a card
		if(!fild1full && playCardTime){
			
			if(Input.IsActionJustPressed("Active")){
				choose_card.SetZIndex(0);
				choose_card.SetGlobalScale(_scaler);
				choose_card.SetGlobalPosition(field1_pos[fill_number]);
				card_fild1.Add(choose_card);
				playerOneHand.Remove(choose_card);

				sortHandCards();
				playCardTime=!playCardTime;

				if(fill_number <2){
					fill_number ++;
				}
				else{
					fild1full = !fild1full;
				}

				if(playerTwo && firsRound){
					firsRound=false;
					nextplayer();
				}
				

			}

		}

	}
  	 
  }

	public void nextplayer(){
		GD.Print("Hi");
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


		

  

  private void _on_EndTurnButton_pressed() {
	foreach (var item in playerOneHand)
	{
		item.SetVisible(false);
	}
	if(playerOne){
		playerOne = false;
		firstDrawPlayerOne = false;
		playerTwo = true;
	}
	_StartTurnButton.SetVisible(true);
	_EndTurnButton.SetVisible(false);
  }

  private void _on_StartTurnButton_pressed() {

  }

}

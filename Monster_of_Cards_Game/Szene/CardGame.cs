using Godot;
using System.Collections.Generic;
using System;

public class CardGame : Node2D
{
	//All Cards
	public PackedScene simultaneousScene ;

	private Monster_01_2D  _Monster01, _Monster02,  _Monster03, _Monster04,  _Monster05, _Monster06,  _Monster07;
	private Monster_01_2D  _Monster08,  _Monster09, _Monster10,  _Monster11,  _Monster12,  _Monster13;	
	private Monster_01_2D  _Monster14,  _Monster15,  _Monster16,  _Monster17,  _Monster18,  _Monster19,  _Monster20;
	private Monster_01_2D  _Monster21,  _Monster22, _Monster23,  _Monster24,  _Monster25, _Monster26;

	private Vector2 _scaler= new Vector2(0.2f,0.2f);
	private Vector2 _scalerBig = new Vector2(0.4f,0.4f);
	private Random random;

//Spieler
	private Player PlayerOne = new Player();
	private Player PlayerTwo = new Player();
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
	private deck_number number_cards_in_deck1;
	
	//Feld Player one
	int fill_number=0;
	
	private List<Vector2> field1_pos = new List<Vector2>();
	private List<Monster_01_2D> card_field1 = new List<Monster_01_2D>();

	//for player two
	private bool playerTwo = false; //if it is Player one turne
	private bool firstDrawPlayerTwo = true;
	private List<Monster_01_2D> myCardList2 = new List<Monster_01_2D>();
	private deck_number number_cards_in_deck2;
	
	//Field Player Two
	int fill_number2=0;
	
	private List<Vector2> field2_pos = new List<Vector2>();
	private List<Monster_01_2D> card_field2 = new List<Monster_01_2D>();

	private Button _EndTurnButton;
	private Button _StartTurnButton;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		//ToDo
		PlayerTwo.setHand_pos(new Vector2(200,100));
		PlayerTwo.setHand_pos(new Vector2(300,100));
		PlayerTwo.setHand_pos(new Vector2(400,100));
		PlayerTwo.setHand_pos(new Vector2(500,100));
		PlayerTwo.setHand_pos(new Vector2(600,100));
		PlayerTwo.setHand_pos(new Vector2(700,100));

		field2_pos.Add(new Vector2(100,230));
		field2_pos.Add(new Vector2(260,230));
		field2_pos.Add(new Vector2(420,230));
		
		
		//Hand Positionen Player one
		PlayerOne.setHand_pos(new Vector2(200,490));
		PlayerOne.setHand_pos(new Vector2(300,490));
		PlayerOne.setHand_pos(new Vector2(400,490));
		PlayerOne.setHand_pos(new Vector2(500,490));
		PlayerOne.setHand_pos(new Vector2(600,490));
		PlayerOne.setHand_pos(new Vector2(700,490));
		//Feld Positionen Player one
		field1_pos.Add(new Vector2(100,360));
		field1_pos.Add(new Vector2(260,360));
		field1_pos.Add(new Vector2(420,360));
		
		//Dec Player one
		// Send
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

		_Monster14 = crateCard("Monster_14","res://Assets/Monsters/Monster_01.png",3,3, "Test","Hallo Welt");
		_Monster15 = crateCard("Monster_15","res://Assets/Monsters/Monster_02.png",3,3, "Name","Hallo Welt");
		_Monster16 = crateCard("Monster_16","res://Assets/Monsters/Monster_03.png",3,3, "Name","Hallo Welt, was Geht so ab?");
		_Monster17 = crateCard("Monster_17","res://Assets/Monsters/Monster_04.png",3,3, "Name","Hallo Welt, Ich bin ein böses Monster der Unterwelt");
		_Monster18 = crateCard("Monster_18","res://Assets/Monsters/Monster_05.png",3,3, "Name","Hallo Welt, Ich bin ein böses Monster der Unterwelt");
		_Monster19 = crateCard("Monster_19","res://Assets/Monsters/Monster_06.png",3,3, "Name","Hallo Welt, Ich bin ein böses Monster der Unterwelt");
		_Monster20 = crateCard("Monster_20","res://Assets/Monsters/Monster_07.png",3,3, "Name","Hallo Welt, Ich bin ein böses Monster der Unterwelt");
		_Monster21 = crateCard("Monster_21","res://Assets/Monsters/Monster_08.png",3,3, "Name","Hallo Welt, Ich bin ein böses Monster der Unterwelt");
		_Monster22 = crateCard("Monster_22","res://Assets/Monsters/Monster_09.png",3,3, "Name","Hallo Welt, Ich bin ein böses Monster der Unterwelt");
		_Monster23 = crateCard("Monster_23","res://Assets/Monsters/Monster_10.png",3,3, "Name","Hallo Welt, Ich bin ein böses Monster der Unterwelt");
		_Monster24 = crateCard("Monster_24","res://Assets/Monsters/Monster_11.png",3,3, "Name","Hallo Welt, Ich bin ein böses Monster der Unterwelt");
		_Monster25 = crateCard("Monster_25","res://Assets/Monsters/Monster_12.png",3,3, "Name","Hallo Welt, Ich bin ein böses Monster der Unterwelt");
		_Monster26 = crateCard("Monster_26","res://Assets/Monsters/Monster_13.png",3,3, "Name","Hallo Welt, Ich bin ein böses Monster der Unterwelt");

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

		myCardList2.Add(_Monster14);
		myCardList2.Add(_Monster15);
		myCardList2.Add(_Monster16);
		myCardList2.Add(_Monster17);
		myCardList2.Add(_Monster18);
		myCardList2.Add(_Monster19);
		myCardList2.Add(_Monster20);
		myCardList2.Add(_Monster21);
		myCardList2.Add(_Monster22);
		myCardList2.Add(_Monster23);
		myCardList2.Add(_Monster24);
		myCardList2.Add(_Monster25);
		myCardList2.Add(_Monster26);

		number_cards_in_deck1 = GetNode<deck_number>("Card_back/deck_number1");
		number_cards_in_deck1.SetText(myCardList1.Count.ToString()+" Cards");

		number_cards_in_deck2 = GetNode<deck_number>("Card_back2/deck_number2");
		number_cards_in_deck2.SetText(myCardList2.Count.ToString()+" Cards");
		
		_EndTurnButton = GetNode<Button>("EndTurnButton");
		_StartTurnButton = GetNode<Button>("StartTurnButton");

		GD.Randomize();
		random = new Random();					
		}

  public override void _Process(float delta)
  {	
	 if(Input.IsActionJustPressed("draw")){	
		cardhighlighted=false;		
			//erster zug
			if(firstDrawPlayerOne || firstDrawPlayerTwo){				
					if(playerOne && firstDrawPlayerOne){
						for(int i = 0; i <=4; i++){
							int index = random.Next(myCardList1.Count);
							var card_to_move = myCardList1[index];
							PlayerOne.setPlayerHandCard(card_to_move);
							myCardList1.RemoveAt(index);
							number_cards_in_deck1.SetText(myCardList1.Count.ToString()+" Cards");
						
						}
						firstDrawPlayerOne = false;
						PlayerOne.sortHandCards();
						playCardTime=true;

					}
					else if(playerTwo && firstDrawPlayerTwo){
						//Umschreiben für Speiler zwei
						for(int i = 0; i <=4; i++){
							int index = random.Next(myCardList2.Count);
							var card_to_move = myCardList2[index];
							PlayerTwo.setPlayerHandCard(card_to_move);
							myCardList2.RemoveAt(index);
							number_cards_in_deck2.SetText(myCardList2.Count.ToString()+" Cards");
						
						}
						firstDrawPlayerTwo = false;
						PlayerTwo.sortHandCards();
						playCardTime=true;
					}
					else{
						GD.Print("Falsche Taste");
					}
				}
			}

			//alleweiteren Züge
			else if(!playCardTime && !battelTime){
				if(playerOne && drawCard){
					int index_n = random.Next(myCardList1.Count);
					var card_to_move = myCardList1[index_n];
					PlayerOne.setPlayerHandCard(card_to_move);
					myCardList1.RemoveAt(index_n);
					number_cards_in_deck1.SetText(myCardList1.Count.ToString()+" Cards");

					drawCard=!drawCard;
					PlayerOne.sortHandCards();
					playCardTime=true;

				}
				else if (playerTwo && drawCard){

					int index_n = random.Next(myCardList2.Count);
					var card_to_move = myCardList2[index_n];					
					myCardList2.RemoveAt(index_n);
					PlayerTwo.setPlayerHandCard(card_to_move);
					number_cards_in_deck2.SetText(myCardList2.Count.ToString()+" Cards");

					drawCard=!drawCard;
					PlayerTwo.sortHandCards();
					playCardTime=true;
			
				}
				else{
					GD.Print("Falsche Taste2");
				}
			}
		else{
			GD.Print("kannst nicht ziehen");
		}
	

	//Haver card
	if(playerOne)
	{
		if(!cardhighlighted && playCardTime){
			
		if(Input.IsActionJustPressed("Active")){
			
			cardhighlighted = PlayerOne.highlightaCard();				
		}

		}
		else if(cardhighlighted && playCardTime ){
			
			if(Input.IsActionJustPressed("go_right") ){
				PlayerOne.moveHighlightHandCards("go_right");

			}
			if(Input.IsActionJustPressed("go_left")){
				PlayerOne.moveHighlightHandCards("go_left");
			}
		}
	}

	if(playerTwo)
	{		
		if(!cardhighlighted && playCardTime){
		if(Input.IsActionJustPressed("Active")){
				cardhighlighted = PlayerTwo.highlightaCard();
		}

		}
		else if(cardhighlighted && playCardTime ){
			
			if(Input.IsActionJustPressed("go_right") ){
				PlayerTwo.moveHighlightHandCards("go_right");

			}
			if(Input.IsActionJustPressed("go_left")){
				PlayerTwo.moveHighlightHandCards("go_left");
			}
		}
	}

 	//play a card
	if( playCardTime && cardhighlighted)
	{
							
			if(playerOne && !PlayerOne.fieldfull && Input.IsActionJustPressed("PlayACard")){
					var choose_card = PlayerOne.getChoose_card();
					choose_card.SetZIndex(0);
					
					choose_card.SetGlobalScale(_scaler);
					choose_card.SetGlobalPosition(field1_pos[fill_number]);
					card_field1.Add(choose_card);
					PlayerOne.removeaCard(choose_card);
					
					cardhighlighted=false;
					playCardTime=!playCardTime;
					battelTime=true;

					if(fill_number <2){
						fill_number ++;
					}
					else{
						PlayerOne.fieldfull = !PlayerOne.fieldfull;
					}

					if(playerTwo && firsRound){
						firsRound=false;
						nextplayer();
					}					
				}

				if(playerTwo && !PlayerTwo.fieldfull && Input.IsActionJustPressed("PlayACard")){
					var choose_card = PlayerTwo.getChoose_card();
					choose_card.SetZIndex(0);
					
					choose_card.SetGlobalScale(_scaler);
					choose_card.SetGlobalPosition(field2_pos[fill_number2]);
					card_field2.Add(choose_card);
					PlayerTwo.removeaCard(choose_card);
					
					cardhighlighted=false;
					playCardTime=!playCardTime;
					battelTime=true;

					if(fill_number2 <2){
						fill_number2 ++;
					}
					else{
						PlayerTwo.fieldfull = !PlayerTwo.fieldfull;
					}
				}
	}
	
  	 
//  // IF Zugfase

//   if(!cardhighlighted && battelTime){

// 			cardhighlighted = highlight(card_field1);
			
// 			GD.Print(cardhighlighted);
// 			GD.Print(battelTime);

// 		}

// 	else if(cardhighlighted && battelTime){
		
// 		if(Input.IsActionJustPressed("go_right") ){
// 			moveHighlight(card_field1.Count,card_field1,"go_right");
		
// 		}
// 		else if(Input.IsActionJustPressed("go_left")){
// 			moveHighlight(card_field1.Count,card_field1,"go_left");
			
// 		}
// 		else if(Input.IsActionJustPressed("Active")){
// 				choose_card.SetZIndex(0);
// 				choose_card.SetGlobalScale(_scaler);

// 		}

// 	}
  }

	public void nextplayer(){
		
		GD.Print("Hi");

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
		
		if(playerOne){
			foreach (var item in PlayerOne.getPlayerHand())
			{
				item.SetVisible(false);
			}
			playerOne = false;
			firstDrawPlayerOne = false;
			playerTwo = true;
			battelTime=false;
		}
		else if(playerTwo){
			foreach (var item in PlayerTwo.getPlayerHand())
			{
				item.SetVisible(false);
			}
			playerTwo = false;
			firstDrawPlayerTwo = false;
			playerOne = true;
			battelTime=false;
		}

		_StartTurnButton.SetVisible(true);
		_EndTurnButton.SetVisible(false);
	}

	private void _on_StartTurnButton_pressed() {
		
		if(playerOne) {
			foreach (var item in PlayerOne.getPlayerHand())
			{
				item.SetVisible(true);
			}
		}
		else if(playerTwo) {
			foreach (var item in PlayerTwo.getPlayerHand())
			{
				item.SetVisible(true);
			}
		}		
		
		_StartTurnButton.SetVisible(false);
		_EndTurnButton.SetVisible(true);

		if(!(firstDrawPlayerOne) && !(firstDrawPlayerTwo)) {
			drawCard=true;
		}
	}

}

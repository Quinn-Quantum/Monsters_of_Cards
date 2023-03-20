using Godot;
using Godot.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;




public class Player 
{

  public int lifePoint = 10;
   public bool fieldfull=false;
   private List<Monster_01_2D> playerHand = new List<Monster_01_2D>(); 
//ausgewählte Handkarte
   private Monster_01_2D choose_card;
//Karten größe
   private Vector2 _scaler= new Vector2(0.2f,0.2f);
	private Vector2 _scalerBig = new Vector2(0.4f,0.4f);
   private  List<Monster_01_2D> card_field = new List<Monster_01_2D>();

   //Hand Positionen
	private List<Vector2> hand_pos = new List<Vector2>();
	private int pos;
	private int max_pos;
	private int min_pos = 0;


    private Random random;

     public void setPlayerHandCard(Monster_01_2D  value)
  {
        
        playerHand.Add(value); 
        value.SetVisible(true);
    
  }
    public List<Monster_01_2D> getPlayerHand()
  {
       return playerHand; 
       
    
  }

    public void setHand_pos(Vector2  value)
  {
        
        hand_pos.Add(value); 
    
  }
    public List<Vector2> getHand_pos()
  {
       return hand_pos; 
       
    
  }

   public void setCard_fields(Monster_01_2D  value)
  {
        
        card_field.Add(value); 
    
  }
    public List<Monster_01_2D> getCard_field()
  {
       return card_field; 
       
    
  }

   public void setChoose_card(Monster_01_2D  value)
  {
        
        choose_card = value; 
    
  }
    public Monster_01_2D getChoose_card()
  {
       return choose_card; 
       
    
  }

  public void removeaCard(Monster_01_2D  value){
    playerHand.Remove(value);
    sortHandCards();

  }

  public void sortHandCards(){
		//Handkarten Positoonen
    for(int k=0; k<playerHand.Count; k++){
        var card = playerHand[k];
        card.SetGlobalPosition(hand_pos[k]);
    }
		
	
	}

    public bool highlightaCard(){
		pos = 0;
			choose_card = playerHand[pos];
			choose_card.SetGlobalScale(_scalerBig);
			choose_card.SetZIndex(1);
		return true;
	}

    public void moveHighlightHandCards(String input){
        max_pos = playerHand.Count;
		if(input.Equals( "go_right") ){
		choose_card = playerHand[pos];
			if(pos < max_pos -1){

				choose_card.SetGlobalScale(_scaler);
				choose_card.SetZIndex(0);

				pos = pos +1;
				choose_card = playerHand[pos];
				choose_card.SetGlobalScale(_scalerBig);
				choose_card.SetZIndex(1);

			}
			else{

				choose_card.SetGlobalScale(_scaler);
				choose_card.SetZIndex(0);

				pos=0;
				choose_card = playerHand[pos];
				choose_card.SetGlobalScale(_scalerBig);
				choose_card.SetZIndex(1);

			}

		}
		if(input.Equals("go_left")){
			choose_card = playerHand[pos];
			if(pos > min_pos){

				choose_card.SetGlobalScale(_scaler);
				choose_card.SetZIndex(0);

				pos = pos -1;
				choose_card = playerHand[pos];
				choose_card.SetGlobalScale(_scalerBig);
				choose_card.SetZIndex(1);

			}else{

				choose_card.SetGlobalScale(_scaler);
				choose_card.SetZIndex(0);

				pos= max_pos -1;
				choose_card = playerHand[pos];
				choose_card.SetGlobalScale(_scalerBig);
				choose_card.SetZIndex(1);

			}
	}

	}

  public int addLife(int a){
    lifePoint = lifePoint + a;
    return lifePoint;
  }

   public int minesLife(int a){
    lifePoint = lifePoint - a;
    return lifePoint;
  }

  public String getlifePointAsString(){
    return lifePoint.ToString();
  }
    
}

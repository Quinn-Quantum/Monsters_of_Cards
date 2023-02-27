using Godot;
using System;

public class Sprite : Godot.Sprite
{
    String imagePath_Card;

     [Export]
     String _Image {
         get {return imagePath_Card;}
         set {imagePath_Card = value; 
         }
     }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
       
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    
}

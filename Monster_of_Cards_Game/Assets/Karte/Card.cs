using Godot;
using System;

public class Card : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    private string[] _cards = { "Geist", "Drache", "Pixi", "Banana" };

    public override void _Ready()
    {
        GD.Randomize();

        for (int i = 0; i < 100; i++)
        {
            // Pick 100 fruits randomly.
            GD.Print(GetCard());
        }


    }

    public string GetCard()
    {
        string randomCard = _cards[GD.Randi() % _cards.Length];
        // Returns "apple", "orange", "pear", or "banana" every time the code runs.
        // We may get the same fruit multiple times in a row.
        return randomCard;
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}

using Godot;
using System;

public class Monster_01_2D : Area2D
{
  private int atk;
  private int def;
  private String description;
  private String name;

  
  
  Sprite _Sprite;

  Label_Name _Name;
  Label_Discription _Discription;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
      _Sprite = GetNode<Sprite>("Sprite");
      _Name = GetNode<Label_Name>("Label_Name");
      _Discription = GetNode<Label_Discription>("Label_Discription");

        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
   _Name.SetText(name);
   _Discription.SetText(description);
    
  }

  public void _SetImage(String _path){
       Image i = new Image();
        i.Lock();

        ImageTexture t = new ImageTexture();
        i.Load(_path);
        
        i.Unlock();
        t.CreateFromImage(i);
        _Sprite.Texture = t;

    }

  public void _SetAtk(int _atk){
    atk = _atk;
  }

  public void _SetDef(int _def){
    def = _def;
  }

  public void _SetDescription(String _description){
    description=_description;
  }

  public void _SetName(String _name){
    name=_name;
  }
  
}

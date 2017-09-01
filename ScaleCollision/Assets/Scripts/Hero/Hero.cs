using UnityEngine;
using System.Collections;

public abstract class Hero 
{
    public int id{ get; set;}

    public string heroName{ get; set;}

    public abstract void HeroSkill(GamePlayer player1, GamePlayer player2, out GamePlayer newPlayer1, out GamePlayer newPlayer2);
}

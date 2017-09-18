using System;


public interface IHeroSkill
{
    //所有英雄必须实现这个英雄技能接口。
    void HeroSkill(GamePlayer player1, GamePlayer player2, out GamePlayer newPlayer1, out GamePlayer newPlayer2);
}



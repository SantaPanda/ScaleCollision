using System;
using System.Collections.Generic;


public class PlayerData
{
    public PlayerData()
    {
    }
    public int userId{ get; set;}

    public string userAccount{ get; set;}

    public string userPassword{ get; set;}

    public string name{ get; set;}

    public int golds{ get; set;}

    public int cash{ get; set;}

    public int PortraitId{ get; set;}

    public bool isBgMusicOpen{ get; set;}

    public bool isSoundOpen{ get; set;}

    /// <summary>
    /// 英雄拥有情况。
    /// </summary>
    public Dictionary<int, bool> heroes{ get; set;}

    /// <summary>
    /// 皮肤拥有情况。
    /// </summary>
    public Dictionary<int, bool> skin{ get; set;}

    public int gameCount{ get; set;}

    public int winCount{ get; set;}

    public int loseCount{ get; set;}
}



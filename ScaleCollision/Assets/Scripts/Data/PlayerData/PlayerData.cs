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

    public int heroSelectId{ get; set;}

    /// <summary>
    /// 英雄拥有情况。
    /// </summary>
    private Dictionary<int, bool> mHeroes;
    public Dictionary<int, bool> heroes
    { 
        get
        {
            if (mHeroes == null)
            {
                mHeroes = new Dictionary<int, bool>();
            }
            return mHeroes;
        } 
    }

    /// <summary>
    /// 皮肤拥有情况。
    /// </summary>
    private Dictionary<int, bool> mSkin;
    public Dictionary<int, bool> skin
    { 
        get
        {
            if (mSkin == null)
            {
                mSkin = new Dictionary<int, bool>();
            }
            return mSkin;
        } 
    }

    public int gameCount{ get; set;}

    public int winCount{ get; set;}

    public int loseCount{ get; set;}
}



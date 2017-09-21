using UnityEngine;
using System.Collections;

namespace EnumDataDef
{
    /// <summary>
    /// 界面
    /// </summary>
    public enum UIPanelType
    {
        LoginPanel,    //登录界面
        RegisterPanel,     //注册界面
        MainPanel,    //主界面
        SelectHeroesPanel,    //选择英雄界面
        AboutUsPanel,     //关于我们界面
        GamePanel,     //游戏界面
        TipPanel,     //提示界面
    }
    public enum AudioType
    {
        BgMusic = 0,   //BGM
        Sound = 1,    //音效
    }

    /// <summary>
    /// 台阶id.
    /// </summary>
    public enum ScaleName
    {
        left0 = 0,
        left1 = 1,
        left2 = 2,
        left3 = 3,
        left4 = 4,
        left5 = 5,
        left6 = 6,
        left7 = 7,
        right0 = 8,
        right1 = 9,
        right2 = 10,
        right3 = 11,
        right4 = 12,
        right5 = 13,
        right6 = 14,
        right7 = 15,
    }

    /// <summary>
    /// Hero name.
    /// 英雄id.
    /// </summary>
    public enum HeroName
    {
        hero1 = 10000,
        hero2 = 20000,
        hero3 = 30000,
        hero4 = 20000,
    }
}

using UnityEngine;
using System.Collections;

public class GamePlayer 
{
    //该玩家操作的英雄的ID
    public int heroId{ get; set;}

    //该玩家操作的英雄的名字
    public string heroName{ get; set;}

    //该玩家是否是本人
    public bool isOwn{ get; set;}

    //该玩家的位置
    public Vector3 playerPosition{ get; set;}

    //该玩家的x轴坐标速度
    public float speedX{ get; set;}

    //该玩家的y轴坐标速度
    public float speedY{ get; set;}

    //该玩家的y轴加速度
    public float accelerationY{ get; set;}

    //该玩家是否赢了
    public bool isWin{ get; set;}
}

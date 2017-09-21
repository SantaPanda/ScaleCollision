using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class GamePanel : UIBase
{

	private Button JumpButton;
	private Button SkillButton;

    private RectTransform Player;
    private Rigidbody2D PlayerRigi;

    private List<int> ScaleIdList = new List<int>();
    private List<Sprite> ScaleSprite = new List<Sprite>();
	private List<UIScale> ScaleList = new List<UIScale>();

//    private static readonly string ScaleSpritePath1 = "Images/UI/GamePanel/left{0}";
//    private static readonly string ScaleSpritePath2 = "Images/UI/GamePanel/right{0}";

    private static readonly string ScaleSpritePath = "Images/UI/GamePanel/{0}";

    private object lockScale = new object();

	// Update is called once per frame
	void Update () 
	{
	}

    public override void OnShow(object param)
    {
        base.OnShow(param);
    }

    public override void OnHide()
    {
        base.OnHide();
    }

    protected override void UIInit()
    {
        base.UIInit();
        InitialScale();
    }

    public override void OnCreate()
    {
        //为了使用GameObject.Find();
        CacheGameObject.SetActive(true);

        base.OnCreate();

        Player = GameObject.Find("Player1").GetComponent<RectTransform>();
        PlayerRigi = GameObject.Find("Player1").GetComponent<Rigidbody2D>();

		JumpButton = GameObject.Find("JumpButton").GetComponent<Button>();
        SkillButton = GameObject.Find("SkillButton").GetComponent<Button>();
        JumpButton.onClick.AddListener(() =>
            {
                this.OnClick(JumpButton.gameObject);
            });
        SkillButton.onClick.AddListener(() =>
            {
                this.OnClick(SkillButton.gameObject);
            });

        this.UIInit();

        CacheGameObject.SetActive(false);
	}

    /// <summary>
    /// Initials the scale.
    /// </summary>
    private void InitialScale()
    {
        foreach(var DScale in ScaleData.dataMap)
        {
            Sprite tempSprite = Resources.Load(string.Format(ScaleSpritePath, DScale.Value.imagePath), typeof(Sprite)) as Sprite;
            ScaleSprite.Add(tempSprite);
            ScaleIdList.Add(DScale.Value.id);
            ScaleList.Add(new UIScale(DScale.Value.id));
        }

//        for (int i = 0; i < UIScale.oneSideNum; i++)
//        {
//            Sprite tempSprite = Resources.Load(string.Format(ScaleSpritePath1, i), typeof(Sprite)) as Sprite;
//            ScaleSprite.Add(tempSprite);
//        }
//        for (int i = 0; i < UIScale.oneSideNum; i++)
//        {
//            Sprite tempSprite = Resources.Load(string.Format(ScaleSpritePath2, i), typeof(Sprite)) as Sprite;
//            ScaleSprite.Add(tempSprite);
//        }

//        for (int i = 0; i < UIScale.oneSideNum*2; i++) 
//        {
//            ScaleIdList.Add(i);
//            ScaleList.Add (new UIScale(i));
//        }
    }

    private bool isJumping(Vector3 PlayerPosition)
    {
        Debug.Log(Player.localPosition);
        if (PlayerPosition.y > -234)
        {
            return true;
        }
        return false;
    }

    private void OnClick(GameObject go)
    {
        if (go == JumpButton.gameObject)
        {
            if (!isJumping(Player.localPosition))
            {
                RefreshScale();
                PlayerJump();
                ScaleAnimation(UIScale.GetScalePositionId(Player.transform.localPosition));
            }
        }
        if (go == SkillButton.gameObject)
        {
        }
    }



    /// <summary>
    /// 改变云的颜色
    /// </summary>
    private void RefreshScale()
    {
        lock (lockScale)
        {
            ScaleIdList = UIScale.RandomScale(ScaleIdList);
            for(int i=0; i<UIScale.oneSideNum*2; i++){
                ScaleList[i].RefreshUI(ScaleIdList[i], ScaleSprite[ScaleIdList[i]]);
            }
        }
    }

    /// <summary>
    /// 实现人物跳跃
    /// </summary>
    private void PlayerJump()
    {
        // PlayerRigi.velocity += new Vector2(0, 5); 
        PlayerRigi.AddForce(Vector2.up * 50000);   //乘上每个台阶自带的高度（还没定义）
    }

    /// <summary>
    /// 实现人物移动
    /// </summary>
    private void PlayerMove()
    {
        Player.transform.Translate(Vector2.right * 100 * Time.deltaTime);
    }

    /// <summary>
    /// 调用云的animation。
    /// </summary>
    /// <param name="ScaleIndex">Scale index.</param>
    private void ScaleAnimation(int ScaleIndex)
    {
        if (ScaleIndex >= 0 && ScaleIndex < ScaleList.Count)
            ScaleList[ScaleIndex].PlayAnimation();
    }
}

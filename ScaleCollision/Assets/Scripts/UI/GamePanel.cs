using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class GamePanel : UIBase
{

	private Button JumpButton;
	private Button SkillButton;

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
        foreach(var Scale in ScaleList){
            Scale.Update();
        }
	}

    public override void OnShow(object param)
    {
        base.OnShow(param);
        RefreshScale();
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

    private void OnClick(GameObject go)
    {
        if (go == JumpButton.gameObject)
        {
            RefreshScale();
        }
        if (go == SkillButton.gameObject)
        {
        }
    }

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

    public override void OnHide()
    {
        base.OnHide();
    }
}

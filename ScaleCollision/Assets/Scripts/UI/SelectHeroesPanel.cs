using System;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using EnumDataDef;

public class SelectHeroesPanel : UIBase
{
    class HeroClass : UIBase
    {
        public Button hero;
        public int heroId;

        //委托，用于触发点击事件时的数据传输
        public delegate void HeroDelegate(int heroId);
        public HeroDelegate OnHeroDelegate;

        private readonly static string SpritePathRoot = "Images/UI/SelectHeroesPanel/HeroSprite/{0}";

        /// <summary>
        /// 初始化HeroClass
        /// </summary>
        /// <param name="heroId">Hero identifier.</param>
        /// <param name="SpritePath">Sprite path.</param>
        /// <param name="OnHeroDelegate">On hero delegate.</param>
        public HeroClass()
        {
           
        }

        public void Init(int heroId, string SpritePath, HeroDelegate OnHeroDelegate)
        {
            this.heroId = heroId;
            hero.image.sprite = Resources.Load(string.Format(SpritePathRoot, SpritePath), typeof(Sprite)) as Sprite;
            this.OnHeroDelegate = OnHeroDelegate;
        }

        public override void OnCreate()
        {
            base.OnCreate();
            hero = transform.GetComponent<Button>();
            hero.onClick.AddListener(() =>
                {
                    this.OnClick(hero.gameObject);
                });
        }

        private void OnClick(GameObject go)
        {
            if (go == hero.gameObject)
            {
                if (this.OnHeroDelegate != null)
                {
                    OnHeroDelegate(heroId);
                }
            }
        }
         
        /// <summary>
        /// 用于确认英雄后，不能点击其他英雄（解除所有HeroClass的点击事件委托）。
        /// </summary>
        public void CancelClickEvent()
        {
            this.OnHeroDelegate = null;  
        }
    }

    //GamePanel类
    private Button SureButton;

    private Image StageShow;
    private Image OwnPortrait;
    private Image OppoentPortrait;

    private Text TimerText;

    private float ScrollHeight;
    private float ItemHeight;
    private ScrollRect HeroScroll;
    private RectTransform HeroContent;

    private VerticalLayoutGroup HeroContentLayout;
    private LayoutElement HeroContentLayoutElement;

    private List<HeroClass> heroList;

    private readonly static string heroChildNode = "SelectionArea/HeroScroll/Content/hero";
    //private static string heroName = "hero{0}";

    private readonly static string stageShowPath = "Images/UI/SelectHeroesPanel/StageShow/{0}";
    private readonly static string portraitPath = "Images/UI/SelectHeroesPanel/Portrait/{0}";

    private int SelectHeroId;

    private bool isSelect = false;

    private readonly float SelectHeroTime = 15;
    private readonly float SelectSkinTime = 5;
    
    public SelectHeroesPanel()
    {
    }

    public override void OnCreate()
    {
        base.OnCreate();

        heroList = new List<HeroClass>();

        SureButton = transform.Find("SureButton").GetComponent<Button>();
        SureButton.onClick.AddListener(() =>
            {
                this.OnClick(SureButton.gameObject);
            });

        StageShow = transform.Find("Stage/StageShow").GetComponent<Image>();
        OwnPortrait = transform.Find("OwnPortrait/Portrait").GetComponent<Image>();
        OppoentPortrait = transform.Find("OppoentPortrait/Portrait").GetComponent<Image>();

        TimerText = transform.Find("Timer/Time").GetComponent<Text>();

        HeroScroll = transform.Find("SelectionArea/HeroScroll").GetComponent<ScrollRect>();
        HeroContent = HeroScroll.transform.Find("Content").GetComponent<RectTransform>();
        HeroContentLayout = HeroContent.GetComponent<VerticalLayoutGroup>();
        HeroContentLayoutElement = HeroContent.GetComponent<LayoutElement>();

        ScrollHeight = HeroScroll.GetComponent<RectTransform>().rect.height;
        ItemHeight = HeroContentLayoutElement.minHeight;

        InitHeroes();
    }

    public override void OnShow(object param)
    {
        base.OnShow(param);

        AudioManager.Instance.PlayAudio(BGMId.SelectHeroBGM.ToString(), loop: true, type: EnumDataDef.AudioType.BgMusic);
        StartCoroutine(Countdown1());
    }

    public override void OnHide()
    {
        base.OnHide();

        AudioManager.Instance.StopAudio(BGMId.SelectHeroBGM.ToString());
    }

    protected override void UIInit()
    {
        base.UIInit();

    }

    /// <summary>
    /// Inits the heroes.
    /// </summary>
    #region show all heroes
    private void InitHeroes()
    {
        heroList.Clear();
        foreach (var DHero in HeroData.dataMap)
        {
            HeroClass tempHero = AddElement<HeroClass>(heroChildNode, DHero.Value.heroName);
            tempHero.Init(DHero.Value.id, DHero.Value.heroSprite, ClickHero);
            tempHero.OnShow();
            heroList.Add(tempHero);
        }
        float height = HeroContentLayout.padding.top + HeroContentLayout.padding.bottom + heroList.Count * ItemHeight + (heroList.Count - 1) * HeroContentLayout.spacing;
        HeroContent.sizeDelta = new Vector2(HeroContentLayoutElement.minWidth, height);
    }
    #endregion

    private void OnClick(GameObject go)
    {
        if (go == SureButton.gameObject)
        {
            if (SelectHeroId != 0 && !isSelect)
            {
                StopSelection();
                AudioManager.Instance.PlayAudio(SoundId.SelectHeroSound.ToString());
                isSelect = true;
            }
        }
    }


    /// <summary>
    /// 点击英雄的时候，改变stageShow和ownPortrait的图片.
    /// </summary>
    /// <param name="heroId">Hero identifier.</param>
    private void ClickHero(int heroId)
    {
        SelectHeroId = heroId;
//        foreach (var DHero in HeroData.dataMap)
//        {
//            if (DHero.Value.id == SelectHeroId)
//            {
//                StageShow.sprite = Resources.Load(string.Format(stageShowPath, DHero.Value.stageShow), typeof(Sprite)) as Sprite;
//                StageShow.gameObject.SetActive(true);
//                OwnPortrait.sprite = Resources.Load(string.Format(portraitPath, DHero.Value.portrait), typeof(Sprite)) as Sprite;
//                OwnPortrait.gameObject.SetActive(true);
//            }
//        }
        if(HeroData.dataMap.ContainsKey(SelectHeroId))
        {
            AudioManager.Instance.PlayAudio(SoundId.Click.ToString());
            
            StageShow.sprite = Resources.Load(string.Format(stageShowPath, HeroData.dataMap[SelectHeroId].stageShow), typeof(Sprite)) as Sprite;
            StageShow.gameObject.SetActive(true);
            OwnPortrait.sprite = Resources.Load(string.Format(portraitPath, HeroData.dataMap[SelectHeroId].portrait), typeof(Sprite)) as Sprite;
            OwnPortrait.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// 加载该界面时，根据用户的英雄拥有情况更新UI。
    /// </summary>
    public override void RefreshUI()
    {
        base.RefreshUI();

        heroList.Clear();
    }
     
    /// <summary>
    /// Stops the selection.
    /// 点击确定后禁止选择其他英雄。
    /// </summary>
    public void StopSelection()
    {
        foreach (var tempHero in heroList)
        {
            tempHero.CancelClickEvent();
        }
    }

    /// <summary>
    /// 第一次倒数之后，还没选择英雄，则默认选择初始第一个英雄。
    /// </summary>
    private void DefaultSelection()
    {
        if (!isSelect)
        {
            SelectHeroId = HeroData.dataMap[0].id;

            StageShow.sprite = Resources.Load(string.Format(stageShowPath, HeroData.dataMap[0].stageShow), typeof(Sprite)) as Sprite;
            StageShow.gameObject.SetActive(true);
            OwnPortrait.sprite = Resources.Load(string.Format(portraitPath, HeroData.dataMap[0].portrait), typeof(Sprite)) as Sprite;
            OwnPortrait.gameObject.SetActive(true);
            this.OnClick(SureButton.gameObject);

            AudioManager.Instance.PlayAudio(SoundId.SelectHeroSound.ToString());
        }
    }

    /// <summary>
    /// 倒数计时1,用于选择英雄的倒数计时.
    /// </summary>
    IEnumerator Countdown1()
    {
        for (float timer = SelectHeroTime; timer >= 0; timer -= Time.deltaTime)
        {
            int tempTimer = (int)timer;
            TimerText.text = tempTimer.ToString();
            yield return 0;
        }

        DefaultSelection();

        StartCoroutine(Countdown2());
    }

    /// <summary>
    /// 倒数计时2，用于选择皮肤的倒数计时
    /// </summary>
    IEnumerator Countdown2()
    {
        for (float timer = SelectSkinTime; timer >= 0; timer -= Time.deltaTime)
        {
            int tempTimer = (int)timer;
            TimerText.text = tempTimer.ToString();
            yield return 0;
        }

        UIManger.Instance.ShowPanel(UIPanelType.GamePanel.ToString());
        UIManger.Instance.HidePanel(UIPanelType.SelectHeroesPanel.ToString());
    }
}



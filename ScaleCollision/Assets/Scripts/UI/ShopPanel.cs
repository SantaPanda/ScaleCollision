using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using EnumDataDef;
using LitJson;

public class ShopPanel : UIBase 
{
    private Image HeroLabel1;
    private Image RechargeLabel1;

    private GameObject HeroContent;
    private GameObject RechargeContent;

    private Button HeroLabel2;
    private Button RechargeLabel2;
    private Button ReturnButton;

    private Button Hero1;
    private Button Hero2;
    private Button Hero3;
    private Button Hero4;
    private Image HeroBuy;
    private Button GoldBuy;
    private Button CashBuy;
    private Button Return;

    private Button Recharge1;
    private Button Recharge2;
    private Button Recharge3;
    private Button Recharge4;

    private GameObject Tip;
    private Image Success;
    private Image Fail1;
    private Image Fail2;
    private Button Sure;

    private int SelectHeroId;
    private ConsumptionType SelectType;

    private readonly string SpritePath = "Images/UI/ShopPanel/{0}";

    public override void OnCreate()
    {
        base.OnCreate();

        HeroLabel1 = transform.Find("BG/HeroLabel1").GetComponent<Image>();
        RechargeLabel1 = transform.Find("BG/RechargeLabel1").GetComponent<Image>();

        HeroLabel2 = transform.Find("BG/HeroLabel2").GetComponent<Button>();
        HeroLabel2.onClick.AddListener(() =>
            {
                this.OnClick(HeroLabel2.gameObject);
            });
        RechargeLabel2 = transform.Find("BG/RechargeLabel2").GetComponent<Button>();
        RechargeLabel2.onClick.AddListener(() =>
            {
                this.OnClick(RechargeLabel2.gameObject);
            });
        ReturnButton = transform.Find("BG/ReturnButton").GetComponent<Button>();
        ReturnButton.onClick.AddListener(() =>
            {
                this.OnClick(ReturnButton.gameObject);
            });

        HeroContent = transform.Find("BG/HeroContent").gameObject;
        RechargeContent = transform.Find("BG/RechargeContent").gameObject;

        Hero1 = HeroContent.transform.Find("Hero1").GetComponent<Button>();
        Hero1.onClick.AddListener(() =>
            {
                this.OnClick(Hero1.gameObject);
            });
        Hero2 = HeroContent.transform.Find("Hero2").GetComponent<Button>();
        Hero2.onClick.AddListener(() =>
            {
                this.OnClick(Hero2.gameObject);
            });
        Hero3 = HeroContent.transform.Find("Hero3").GetComponent<Button>();
        Hero3.onClick.AddListener(() =>
            {
                this.OnClick(Hero3.gameObject);
            });
        Hero4 = HeroContent.transform.Find("Hero4").GetComponent<Button>();
        Hero4.onClick.AddListener(() =>
            {
                this.OnClick(Hero4.gameObject);
            });
        HeroBuy = HeroContent.transform.Find("HeroBuy").GetComponent<Image>();
        GoldBuy = HeroContent.transform.Find("HeroBuy/GoldBuy").GetComponent<Button>();
        GoldBuy.onClick.AddListener(() =>
            {
                this.OnClick(GoldBuy.gameObject);
            });
        CashBuy = HeroContent.transform.Find("HeroBuy/CashBuy").GetComponent<Button>();
        CashBuy.onClick.AddListener(() =>
            {
                this.OnClick(CashBuy.gameObject);
            });
        Return = HeroContent.transform.Find("HeroBuy/Return").GetComponent<Button>();
        Return.onClick.AddListener(() =>
            {
                this.OnClick(Return.gameObject);
            });

        Recharge1 = RechargeContent.transform.Find("Recharge1").GetComponent<Button>();
        Recharge1.onClick.AddListener(() =>
            {
                this.OnClick(Recharge1.gameObject);
            });
        Recharge2 = RechargeContent.transform.Find("Recharge2").GetComponent<Button>();
        Recharge2.onClick.AddListener(() =>
            {
                this.OnClick(Recharge2.gameObject);
            });
        Recharge3 = RechargeContent.transform.Find("Recharge3").GetComponent<Button>();
        Recharge3.onClick.AddListener(() =>
            {
                this.OnClick(Recharge3.gameObject);
            });
        Recharge4 = RechargeContent.transform.Find("Recharge4").GetComponent<Button>();
        Recharge4.onClick.AddListener(() =>
            {
                this.OnClick(Recharge4.gameObject);
            });

        Tip = transform.Find("Tip").gameObject;
        Success = Tip.transform.Find("Success").GetComponent<Image>();
        Fail1 = Tip.transform.Find("Fail1").GetComponent<Image>();
        Fail2 = Tip.transform.Find("Fail2").GetComponent<Image>();
        Sure = Tip.transform.Find("Sure").GetComponent<Button>();
        Sure.onClick.AddListener(() =>
            {
                this.OnClick(Sure.gameObject);
            });
    }

    public override void OnShow(object param)
    {
        base.OnShow(param);
        RefreshUI();
    }

    public override void OnHide()
    {
        base.OnHide();
    }

    private void OnClick(GameObject go)
    {
        if (go == HeroLabel2.gameObject)
        {
            AudioManager.Instance.PlayAudio(SoundId.Click.ToString());
            HeroContent.SetActive(true);
            RechargeContent.SetActive(false);
            HeroLabel2.gameObject.SetActive(false);
            HeroLabel1.gameObject.SetActive(true);
            RechargeLabel1.gameObject.SetActive(false);
            RechargeLabel2.gameObject.SetActive(true);
        }

        if (go == RechargeLabel2.gameObject)
        {
            AudioManager.Instance.PlayAudio(SoundId.Click.ToString());
            HeroContent.SetActive(false);
            RechargeContent.SetActive(true);
            HeroLabel2.gameObject.SetActive(true);
            HeroLabel1.gameObject.SetActive(false);
            RechargeLabel1.gameObject.SetActive(true);
            RechargeLabel2.gameObject.SetActive(false);
        }

        if (go == ReturnButton.gameObject)
        {
            AudioManager.Instance.PlayAudio(SoundId.Cancel.ToString());
            UIManger.Instance.ShowPanel(UIPanelType.MainPanel.ToString());
            UIManger.Instance.HidePanel(UIPanelType.ShopPanel.ToString());
        }

        if (go == Hero1.gameObject)
        {
            AudioManager.Instance.PlayAudio(SoundId.Click.ToString());
            HeroBuy.gameObject.SetActive(true);
            SelectHeroId = 10000;
            HeroBuy.sprite = Resources.Load(string.Format(SpritePath, "herobuy1"), typeof(Sprite)) as Sprite;
        }

        if (go == Hero2.gameObject)
        {
            AudioManager.Instance.PlayAudio(SoundId.Click.ToString());
            HeroBuy.gameObject.SetActive(true);
            SelectHeroId = 20000;
            HeroBuy.sprite = Resources.Load(string.Format(SpritePath, "herobuy2"), typeof(Sprite)) as Sprite;
        }

        if (go == Hero3.gameObject)
        {
            AudioManager.Instance.PlayAudio(SoundId.Click.ToString());
            HeroBuy.gameObject.SetActive(true);
            SelectHeroId = 30000;
            HeroBuy.sprite = Resources.Load(string.Format(SpritePath, "herobuy3"), typeof(Sprite)) as Sprite;
        }

        if (go == Hero4.gameObject)
        {
            AudioManager.Instance.PlayAudio(SoundId.Click.ToString());
            HeroBuy.gameObject.SetActive(true);
            SelectHeroId = 40000;
            HeroBuy.sprite = Resources.Load(string.Format(SpritePath, "herobuy4"), typeof(Sprite)) as Sprite;
        }

        if (go == GoldBuy.gameObject)
        {
            AudioManager.Instance.PlayAudio(SoundId.Click.ToString());
            HeroBuy.gameObject.SetActive(false);
            SelectType = ConsumptionType.Golds;
            BuyHero();
        }

        if (go == CashBuy.gameObject)
        {
            AudioManager.Instance.PlayAudio(SoundId.Click.ToString());
            HeroBuy.gameObject.SetActive(false);
            SelectType = ConsumptionType.Cash;
            BuyHero();
        }

        if (go == Return.gameObject)
        {
            AudioManager.Instance.PlayAudio(SoundId.Cancel.ToString());
            HeroBuy.gameObject.SetActive(false);
        }

        if (go == Recharge1.gameObject)
        {
            AudioManager.Instance.PlayAudio(SoundId.Click.ToString());
            Recharge(1000);
        }

        if (go == Recharge2.gameObject)
        {
            AudioManager.Instance.PlayAudio(SoundId.Click.ToString());
            Recharge(3000);
        }

        if (go == Recharge3.gameObject)
        {
            AudioManager.Instance.PlayAudio(SoundId.Click.ToString());
            Recharge(10000);
        }

        if (go == Recharge4.gameObject)
        {
            AudioManager.Instance.PlayAudio(SoundId.Click.ToString());
            Recharge(35000);
        }

        if (go == Sure.gameObject)
        {
            AudioManager.Instance.PlayAudio(SoundId.Cancel.ToString());
            HideTip();
        }
    }
        
    private void BuyHero()
    {
        httpClient http = new httpClient();
        int isSuccess = http.BuyHero(DataCenter.Instance.playerData.userId, SelectType.ToString(), SelectHeroId);
        if (isSuccess == 1)
        {
            DataCenter.Instance.playerData.heroes[SelectHeroId] = true;
            if (SelectType == ConsumptionType.Cash)
            {
                if (SelectHeroId == 10000 || SelectHeroId == 20000)
                {
                    DataCenter.Instance.playerData.cash -= 3000;
                }
                else
                {
                    DataCenter.Instance.playerData.cash -= 1000;
                }
            }
            else
            {
            }
            RefreshUI();
            ShowTip(1);
        }
        else if (SelectType == ConsumptionType.Golds)
        {
            ShowTip(0);
        }
        else
        {
            ShowTip(2);
        }
    }

    private void Recharge(int money)
    {
        httpClient http = new httpClient();
        int isSuccess = http.Recharge(DataCenter.Instance.playerData.userId, money);
        if (isSuccess == 1)
        {
            DataCenter.Instance.playerData.cash += money;
            ShowTip(1);
        }
        else
        {
            ShowTip(2);
        }
    }

    //type:1成功; type:0金币不足; type:2点券不足
    private void ShowTip(int type)
    {
        Tip.SetActive(true);
        if(type == 1)
        {
            Success.gameObject.SetActive(true);
        }
        if(type == 0)
        {
            Fail1.gameObject.SetActive(true);
        }
        if(type == 2)
        {
            Fail2.gameObject.SetActive(true);
        }
    }

    private void HideTip()
    {
        Success.gameObject.SetActive(false);
        Fail1.gameObject.SetActive(false);
        Fail2.gameObject.SetActive(false);
        Tip.SetActive(false);
    }

    public override void RefreshUI()
    {
        base.RefreshUI();

        foreach (var hero in DataCenter.Instance.playerData.heroes)
        {
            if (hero.Value)
            {
                if (hero.Key == 10000)
                {
                    Hero1.interactable = false;
                }
                if (hero.Key == 20000)
                {
                    Hero2.interactable = false;
                }
                if (hero.Key == 30000)
                {
                    Hero3.interactable = false;
                }
                if (hero.Key == 40000)
                {
                    Hero4.interactable = false;
                }
            }
        }
    }
}

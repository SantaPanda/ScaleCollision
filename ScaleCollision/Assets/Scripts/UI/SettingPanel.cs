using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using EnumDataDef;

public class SettingPanel : UIBase
{   
    private Image BgmOn;
    private Image BgmOff;
    private Image SoundOn;
    private Image SoundOff;

    private Image SelectPortrait;

    private Button Portrait;

    private Button BgmButton;
    private Button SoundButton;
    private Button SureButton;
    private Button ReturnButton;

    private Button Portrait1;
    private Button Portrait2;
    private Button Portrait3;
    private Button Portrait4;

    private Text Name;
    private Text Placeholder;

    private bool isBgMusicOpen = false;
    private bool isSoundOpen = false;

    private string name = "Kirito";
    private int portraitId;

    private readonly string portraitPath = "Images/UI/SelectHeroesPanel/Portrait/{0}";

    public override void OnShow(object param)
    {
        base.OnShow(param);

        RefreshUI();
    }

    public override void OnHide()
    {
        base.OnHide();
    }

    public override void OnCreate()
    {
        base.OnCreate();

        BgmOn = transform.Find("BGM_ON").GetComponent<Image>();
        BgmOff = transform.Find("BGM_OFF").GetComponent<Image>();
        SoundOn = transform.Find("Sound_ON").GetComponent<Image>();
        SoundOff = transform.Find("Sound_OFF").GetComponent<Image>();

        SelectPortrait = transform.Find("SelectPortrait").GetComponent<Image>();

        Portrait = transform.Find("Portrait").GetComponent<Button>();
        Portrait.onClick.AddListener(() =>
            {
                this.OnClick(Portrait.gameObject);
            });

        BgmButton = transform.Find("BGM_Button").GetComponent<Button>();
        BgmButton.onClick.AddListener(() =>
            {
                this.OnClick(BgmButton.gameObject);
            });
        SoundButton = transform.Find("Sound_Button").GetComponent<Button>();
        SoundButton.onClick.AddListener(() =>
            {
                this.OnClick(SoundButton.gameObject);
            });
        SureButton = transform.Find("SureButton").GetComponent<Button>();
        SureButton.onClick.AddListener(() =>
            {
                this.OnClick(SureButton.gameObject);
            });
        ReturnButton = transform.Find("ReturnButton").GetComponent<Button>();
        ReturnButton.onClick.AddListener(() =>
            {
                this.OnClick(ReturnButton.gameObject);
            });
        Portrait1 = transform.Find("SelectPortrait/Portrait1").GetComponent<Button>();
        Portrait1.onClick.AddListener(() =>
            {
                this.OnClick(Portrait1.gameObject);
            });
        Portrait2 = transform.Find("SelectPortrait/Portrait2").GetComponent<Button>();
        Portrait2.onClick.AddListener(() =>
            {
                this.OnClick(Portrait2.gameObject);
            });
        Portrait3 = transform.Find("SelectPortrait/Portrait3").GetComponent<Button>();
        Portrait3.onClick.AddListener(() =>
            {
                this.OnClick(Portrait3.gameObject);
            });
        Portrait4 = transform.Find("SelectPortrait/Portrait4").GetComponent<Button>();
        Portrait4.onClick.AddListener(() =>
            {
                this.OnClick(Portrait4.gameObject);
            });

        Placeholder = transform.Find("Name/InputField/Placeholder").GetComponent<Text>();
        Name = transform.Find("Name/InputField/Text").GetComponent<Text>();
    }

    private void OnClick(GameObject go)
    {
        if (go == Portrait.gameObject)
        {
            AudioManager.Instance.PlayAudio(SoundId.Click.ToString());
            this.ShowOrHidePortraitContent();
        }
        
        if (go == BgmButton.gameObject)
        {
            this.ChangeMusicStatic();
        }

        if (go == SoundButton.gameObject)
        {
            this.ChangeSoundStatic();
        }
        if (go == Portrait1.gameObject)
        {
            ChangePortrait(10000);
        }
        if (go == Portrait2.gameObject)
        {
            ChangePortrait(20000);
        }
        if (go == Portrait3.gameObject)
        {
            ChangePortrait(30000);
        }
        if (go == Portrait4.gameObject)
        {
            ChangePortrait(40000);
        }

        if (go == SureButton.gameObject)
        {
            AudioManager.Instance.PlayAudio(SoundId.Click.ToString());
            UIManger.Instance.HidePanel(UIPanelType.SettingPanel.ToString());
        }

        if (go == ReturnButton.gameObject)
        {
            AudioManager.Instance.PlayAudio(SoundId.Cancel.ToString());
            UIManger.Instance.HidePanel(UIPanelType.SettingPanel.ToString());
        }
    }

    private void ChangePortrait(int portraitId)
    {
        this.portraitId = portraitId;
        if (HeroData.dataMap.ContainsKey(portraitId))
        {
            Portrait.image.sprite = Resources.Load(string.Format(portraitPath, HeroData.dataMap[portraitId].portrait), typeof(Sprite)) as Sprite;
        }
    }

    private void ShowOrHidePortraitContent()
    {
        bool isActive = SelectPortrait.gameObject.activeSelf;
        if (isActive)
        {
            SelectPortrait.gameObject.SetActive(false);
        }
        else
        {
            SelectPortrait.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// 改变背景音设置。
    /// </summary>
    private void ChangeMusicStatic()
    {
        if (isBgMusicOpen)
        {
            BgmOn.gameObject.SetActive(false);
            BgmOff.gameObject.SetActive(true);

            AudioManager.Instance.PlayAudio(SoundId.Off.ToString());
            isBgMusicOpen = false;
        }
        else
        {
            BgmOn.gameObject.SetActive(true);
            BgmOff.gameObject.SetActive(false);

            AudioManager.Instance.PlayAudio(SoundId.On.ToString());
            isBgMusicOpen = true;
        }
    }

    /// <summary>
    /// 改变音效设置。
    /// </summary>
    private void ChangeSoundStatic()
    {
        if (isSoundOpen)
        {
            SoundOn.gameObject.SetActive(false);
            SoundOff.gameObject.SetActive(true);

            AudioManager.Instance.PlayAudio(SoundId.Off.ToString());
            isSoundOpen = false;
        }
        else
        {
            SoundOn.gameObject.SetActive(true);
            SoundOff.gameObject.SetActive(false);

            AudioManager.Instance.PlayAudio(SoundId.On.ToString());
            isSoundOpen = true;
        }
    }

    public override void RefreshUI()
    {
        base.RefreshUI();

        if (isBgMusicOpen)
        {
            BgmOn.gameObject.SetActive(true);
            BgmOff.gameObject.SetActive(false);
        }
        else
        {
            BgmOn.gameObject.SetActive(false);
            BgmOff.gameObject.SetActive(true);
        }

        if (isSoundOpen)
        {
            SoundOn.gameObject.SetActive(true);
            SoundOff.gameObject.SetActive(false);
        }
        else
        {
            SoundOn.gameObject.SetActive(false);
            SoundOff.gameObject.SetActive(true);
        }

        Placeholder.text = name;
    }
}



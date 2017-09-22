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

    private Image Portrait;

    private Button BgmButton;
    private Button SoundButton;
    private Button SureButton;
    private Button ReturnButton;

    private Text Name;
    private Text Placeholder;

    private bool isBgMusicOpen = false;
    private bool isSoundOpen = false;

    private string name = "Kirito";
    private int portraitId;

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

        Portrait = transform.Find("Portrait").GetComponent<Image>();

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
        Placeholder = transform.Find("Name/InputField/Placeholder").GetComponent<Text>();
        Name = transform.Find("Name/InputField/Text").GetComponent<Text>();
    }

    private void OnClick(GameObject go)
    {
        if (go == BgmButton.gameObject)
        {
            this.ChangeMusicStatic();
        }

        if (go == SoundButton.gameObject)
        {
            this.ChangeSoundStatic();
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



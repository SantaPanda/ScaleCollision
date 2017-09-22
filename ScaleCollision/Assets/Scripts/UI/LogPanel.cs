using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using EnumDataDef;

public class LogPanel : UIBase
{
    private Button SureButton;

    private Text Total;
    private Text Win;
    private Text Lose;

    private int totalCount = 233;
    private int winCount = 122;
    private int loseCount = 111;

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

        SureButton = transform.Find("SureButton").GetComponent<Button>();
        SureButton.onClick.AddListener(() =>
            {
                this.OnClick(SureButton.gameObject);
            });

        Total = transform.Find("TotalCount").GetComponent<Text>();
        Win = transform.Find("WinCount").GetComponent<Text>();
        Lose = transform.Find("LoseCount").GetComponent<Text>();
    }

    private void OnClick(GameObject go)
    {
        //隐藏LogPanel.
        if (go == SureButton.gameObject)
        {
            AudioManager.Instance.PlayAudio(SoundId.Cancel.ToString());
            UIManger.Instance.HidePanel(UIPanelType.LogPanel.ToString());
        }
    }

    public override void RefreshUI()
    {
        base.RefreshUI();

        Total.text = totalCount.ToString();
        Win.text = winCount.ToString();
        Lose.text = loseCount.ToString();
    }
}




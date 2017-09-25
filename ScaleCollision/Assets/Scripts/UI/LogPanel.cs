using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using EnumDataDef;
using LitJson;

public class LogPanel : UIBase
{
    private Button SureButton;

    private Text Total;
    private Text Win;
    private Text Lose;

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

        httpClient http = new httpClient();
        JsonData json = http.GetGameRecord(DataCenter.Instance.playerData.userId);
        int isSuccess = DataManger.Instance.AnalyzeLogJson(json);
        if (isSuccess == 1)
        {
            Total.text = DataCenter.Instance.playerData.gameCount.ToString();
            Win.text = DataCenter.Instance.playerData.winCount.ToString();
            Lose.text = DataCenter.Instance.playerData.loseCount.ToString();
        }
        else
        {
            this.OnClick(SureButton.gameObject);
            TipPanel.ShowTip("抱歉，无法获取战绩!");
        }
    }
}




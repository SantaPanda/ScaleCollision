using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TipPanel : UIBase
{
    private Button SureButton;
    private Button ReturnButton1;
    private Button ReturnButton2;

    private Text Tip;

    public override void OnShow(object param)
    {
        base.OnShow(param);
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
        ReturnButton1 = transform.Find("ReturnButton1").GetComponent<Button>();
        ReturnButton1.onClick.AddListener(() =>
            {
                this.OnClick(ReturnButton1.gameObject);
            });
        ReturnButton2 = transform.Find("ReturnButton2").GetComponent<Button>();
        ReturnButton2.onClick.AddListener(() =>
            {
                this.OnClick(ReturnButton2.gameObject);
            });

        Tip = transform.Find("Tip").GetComponent<Text>();
    }

    private void OnClick(GameObject go)
    {
        if (go == SureButton.gameObject)
        {
        }

        if (go == ReturnButton1.gameObject)
        {
        }

        if (go == ReturnButton2.gameObject)
        {
        }
    }
}



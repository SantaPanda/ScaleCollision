using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LoadingPanel : UIBase
{
    private Animator LoadingAnimator;
    private Image LoadingImage;

    public override void OnShow(object param)
    {
        base.OnShow(param);
        AnimationController(true);
        StartCoroutine(StopLoading());
    }

    IEnumerator StopLoading()
    {
        while (true)
        {
            AnimatorStateInfo animatorInfo = LoadingAnimator.GetCurrentAnimatorStateInfo(0);
            if ((animatorInfo.normalizedTime >= 1.0f))//normalizedTime: 范围0 -- 1,  0是动作开始，1是动作结束
            {
                UIManger.Instance.HidePanel(EnumDataDef.UIPanelType.LoadingPanel.ToString());
            }
            yield return 0;
        }
    }

    public override void OnCreate()
    {
        LoadingImage = transform.Find("BG/LoadingAnimation").GetComponent<Image>();
        LoadingAnimator = LoadingImage.GetComponent<Animator>();
    }

    public override void OnHide()
    {
        base.OnHide();
        AnimationController(false);
        StopCoroutine(StopLoading());
    }

    public void AnimationController(bool s)
    {
        if(s==true)
        {
            LoadingAnimator.SetTrigger("Loading");
        }
        else
        {
            LoadingAnimator.SetTrigger("Hide");
        }
    }
}

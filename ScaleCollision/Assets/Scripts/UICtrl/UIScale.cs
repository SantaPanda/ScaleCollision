using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//this class is to control UIScale.
public class UIScale{
	public int id;
	public int ScaleId{ get; set;}

    private string LeftScaleName = "Scale/LeftScale/LeftScale{0}";
    private string RightScaleName = "Scale/RightScale/RightScale{0}";
    private static readonly int oneSideNum = 8;
    private static readonly int oneScaleLength = 80;

	public Image mScale;

	public UIScale(int id)
	{
		this.id = id;
        SetUI();
	}

	public void SetUI()
	{
        if (id < oneSideNum) 
        {
            mScale = GameObject.Find(string.Format(LeftScaleName, id)).GetComponent<Image>();
        } else 
        {
            mScale = GameObject.Find (string.Format (RightScaleName, id-oneSideNum)).GetComponent<Image> ();
        }
        ScaleId = id;
	}

    public void RefreshUI(int ScaleId, Sprite sprite)
	{
        this.ScaleId = ScaleId;
        mScale.sprite = sprite;
	}
        

    //when player is jumping, getting which scale he has jumped.
    public static int GetScalePositionId(Vector3 playerPosition)
    {
        float positionX = playerPosition.x;
        int ScalePositionId = 0;
        if (positionX < 0)
        {
            float absPositionX = System.Math.Abs(positionX);
            ScalePositionId = (int)(oneSideNum - absPositionX / oneScaleLength - 1);
        }
        else
        {
            ScalePositionId = (int)(2 * oneSideNum - positionX / oneScaleLength - 1);
        }
        return ScalePositionId;
    }

    //Random Scales Sequence.
    public static List<int> RandomScale(List<int> ScaleIdList)
    {
        int length = ScaleIdList.Count / 2;
        int[] tempList = new int[length];

        for (int i = 0; i < length; i++)
        {
            tempList[i] = ScaleIdList[i];
        }

        //range pick 1-length, to avoid changing the white cloud(防止改变了两端的缓冲地带).
        for (int i = 0; i < 100; i++)
        {
            int randomIndex1 = Random.Range(1, length);
            int randomIndex2 = Random.Range(1, length);
            int temp = tempList[randomIndex1];
            tempList[randomIndex1] = tempList[randomIndex2];
            tempList[randomIndex2] = temp;
        }

        List<int> newScaleIdList = new List<int>();

        for (int i = 0; i < length; i++)
        {
            newScaleIdList.Add(tempList[i]);
        }
        for (int i = 0; i < length; i++)
        {
            newScaleIdList.Add(tempList[i]+oneSideNum);   
        }
        return newScaleIdList;
    }
}

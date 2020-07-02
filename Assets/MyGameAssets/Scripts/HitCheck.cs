using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 入力された場所が当たりか外れかの判定
/// </summary>
public class HitCheck : MonoBehaviour
{
    
    private static const int rightNum = 0;
    private static const int centerNum = 1;
    private static const int leftNum = 2;

    int checkNum = 0;
    GameObject rightObject;
    GameObject centerObject;
    GameObject leftObject;

    // Start is called before the first frame update
    private void Start()
    {
        rightObject = transform.GetChild(checkNum).GetChild(rightNum).GetChild(0).gameObject;
        centerObject = transform.GetChild(checkNum).GetChild(centerNum).GetChild(0).gameObject;
        leftObject = transform.GetChild(checkNum).GetChild(leftNum).GetChild(0).gameObject;
    }

    /// <summary>
    /// 右が当たりかどうか
    /// </summary>
    /// <returns></returns>
    public bool IsRightHit()
    {
        if(rightObject.tag == "HitObject")
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 中央が当たりかどうか
    /// </summary>
    /// <returns></returns>
    public bool IsCenterHit()
    {
        if (centerObject.transform.tag == "HitObject")
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 左が当たりかどうか
    /// </summary>
    /// <returns></returns>
    public bool IsLeftHit()
    {
        if (leftObject.tag == "HitObject")
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 当たりを全て当てたかどうか
    /// </summary>
    /// <returns></returns>
    public bool IsAllHit()
    {
        return false;
    }
}

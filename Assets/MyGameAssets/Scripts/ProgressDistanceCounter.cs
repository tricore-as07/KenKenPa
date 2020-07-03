using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 前進した距離をカウントしておくクラス
/// </summary>
public class ProgressDistanceCounter : MonoBehaviour
{
    float distanceCounter;

    /// <summary>
    /// 最初に行う処理
    /// </summary>
    void Start()
    {
        distanceCounter = 0;
    }

    /// <summary>
    /// プレイヤーが前進した時に呼ばれる
    /// </summary>
    /// <param name="progressDistance">前進した距離</param>
    public void ProgressPlayer(float progressDistance)
    {
        distanceCounter += progressDistance;
    }

    
}

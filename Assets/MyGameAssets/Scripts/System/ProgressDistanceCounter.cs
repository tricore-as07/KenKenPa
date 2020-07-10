using UnityEngine;

/// <summary>
/// 前進した距離をカウントしておくクラス
/// </summary>
/// FIXME : orimoto MonoBehaviourを継承しない形に修正予定
public class ProgressDistanceCounter : MonoBehaviour
{
    float distanceCounter;      //進んだ距離をカウントする

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
    public void OnProgressPlayer(float progressDistance)
    {
        distanceCounter += progressDistance;
    }
}

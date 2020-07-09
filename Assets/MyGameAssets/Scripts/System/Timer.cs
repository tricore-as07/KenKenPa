using UnityEngine;

/// <summary>
/// 制限時間のタイマー
/// </summary>
public class Timer : MonoBehaviour
{
    [SerializeField]float limitTime = 0f;       //制限時間

    /// <summary>
    /// 毎フレーム行う処理
    /// </summary>
    void Update()
    {
        limitTime -= Time.deltaTime;
        //制限時間がなくなったら
        if(limitTime <= 0)
        {

        }
    }
}

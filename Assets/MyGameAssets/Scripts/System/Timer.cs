using UnityEngine;

/// <summary>
/// 制限時間のタイマー
/// </summary>
public class Timer : MonoBehaviour
{
    [SerializeField] float limitTime = 0f;       //制限時間
    public float LimitTime => limitTime;         //外部に公開するためのプロパティ

    /// <summary>
    /// 毎フレーム行う処理
    /// </summary>
    void Update()
    {
        limitTime -= Time.deltaTime;
        //制限時間がなくなったら
        if(limitTime <= 0)
        {
            OnTimeLIimit();
        }
    }

    /// <summary>
    /// 制限時間が無くなった時によばれる
    /// </summary>
    void OnTimeLIimit()
    {

    }
}

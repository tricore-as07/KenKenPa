using UnityEngine;

/// <summary>
/// 時間でオブジェクトを削除する
/// </summary>
public class DestroyByTime : MonoBehaviour
{
    [SerializeField] float lifeTime;        //アタッチしているオブジェクトを消すまでの時間

    /// <summary>
    /// 最初に行う処理
    /// </summary>
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}

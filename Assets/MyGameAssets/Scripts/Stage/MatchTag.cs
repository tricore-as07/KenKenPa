using UnityEngine;

/// <summary>
/// 子のオブジェクトとタグを合わせる
/// </summary>
public class MatchTag : MonoBehaviour
{
    /// <summary>
    /// 最初に行う処理
    /// </summary>
    void Start()
    {
        tag = transform.GetChild(0).tag;
    }
}

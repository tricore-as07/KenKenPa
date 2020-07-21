using UnityEngine;

/// <summary>
/// ステージを削除する
/// </summary>
public class StageDeleter : MonoBehaviour
{
    /// <summary>
    /// オブジェクトが非アクティブになった時によばれる
    /// </summary>
    void OnDisable()
    {
        Destroy(gameObject);
    }
}

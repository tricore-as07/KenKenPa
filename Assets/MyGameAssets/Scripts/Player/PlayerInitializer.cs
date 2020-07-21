using UnityEngine;

/// <summary>
/// プレイヤーの初期化処理をする
/// </summary>
public class PlayerInitializer : MonoBehaviour
{
    /// <summary>
    /// オブジェクトがアクティブになった時によばれる
    /// </summary>
    void OnEnable()
    {
        transform.position = Vector3.zero;
    }
}

using UnityEngine;

/// <summary>
/// モックシーンの初期化をする
/// </summary>
public class InitializeMockScene : MonoBehaviour
{
    /// <summary>
    /// オブジェクトがアクティブになった時によばれる
    /// </summary>
    void OnEnable()
    {
        ComboCounter.Initialize();
        ProgressDistanceCounter.Initialize();
    }
}

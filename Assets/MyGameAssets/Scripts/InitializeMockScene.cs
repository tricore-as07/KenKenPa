using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// モックシーンの初期化をする
/// </summary>
public class InitializeMockScene : MonoBehaviour
{
    [SerializeField] Text distText = default;
    [SerializeField] Text comboText = default;

    /// <summary>
    /// スクリプトのインスタンスがロードされた時に呼ばれる
    /// </summary>
    void Awake()
    {
        ProgressDistanceCounter.SetDistText(distText);
        ComboCounter.SetComboText(comboText);
    }

    /// <summary>
    /// オブジェクトがアクティブになった時によばれる
    /// </summary>
    void OnEnable()
    {
        ComboCounter.Initialize();
        ProgressDistanceCounter.Initialize();
    }
}

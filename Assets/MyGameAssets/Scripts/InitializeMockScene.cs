using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// モックシーンの初期化をする
/// </summary>
public class InitializeMockScene : MonoBehaviour
{
    [SerializeField] Text distText = default;           //進んだ距離を表示するText
    [SerializeField] Text comboText = default;          //コンボを表示するText
    [SerializeField] Timer timer = default;             //タイマークラス

    /// <summary>
    /// スクリプトのインスタンスがロードされた時に呼ばれる
    /// </summary>
    void Awake()
    {
        ProgressDistanceCounter.SetDistText(distText);
        ComboCounter.SetComboText(comboText);
        ComboCounter.SetTimer(timer);
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

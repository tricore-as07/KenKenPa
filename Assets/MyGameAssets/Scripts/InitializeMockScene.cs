﻿using UnityEngine;
using TMPro;

/// <summary>
/// モックシーンの初期化をする
/// </summary>
public class InitializeMockScene : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI distText = default;            //進んだ距離を表示するText

    /// <summary>
    /// スクリプトのインスタンスがロードされた時に呼ばれる
    /// </summary>
    void Awake()
    {
        ProgressDistanceCounter.SetDistText(distText);
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

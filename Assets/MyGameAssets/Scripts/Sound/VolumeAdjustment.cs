using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ボリュームを調整する
/// </summary>
public class VolumeAdjustment : MonoBehaviour
{
    [SerializeField] Slider volumeSlider = default;                         //ボリュームを変更するスライダー
    [SerializeField] VolumeKey key = default;                               //何のボリュームを設定するか
    public delegate void OnChangeVolumeEvent();                             //ボリュームが変更された時に呼ぶ関数のデリゲート
    public static event OnChangeVolumeEvent onChangeVolumeEvent;            //ボリュームが変更された時に呼ぶイベント

    /// <summary>
    /// スクリプトのインスタンスがロードされた時に呼ばれる
    /// </summary>
    void Awake()
    {
        volumeSlider.value = PlayerPrefs.GetFloat(key.ToString(), 1f);
    }

    /// <summary>
    /// ボリュームが変更された時に呼ばれる
    /// </summary>
    public void OnChangeVolume()
    {
        var volume = volumeSlider.value;
        PlayerPrefs.SetFloat(key.ToString(), volume);
        onChangeVolumeEvent?.Invoke();
    }
}

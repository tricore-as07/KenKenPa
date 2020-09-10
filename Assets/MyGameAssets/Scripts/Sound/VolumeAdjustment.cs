using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ボリュームを調整する
/// </summary>
public class VolumeAdjustment : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;       //ボリュームを変更するスライダー
    [SerializeField] VolumeKey key;             //何のボリュームを設定するか

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
    }
}

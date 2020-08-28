using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// BGMの音量を調整する
/// </summary>
public class BGMVolume : MonoBehaviour
{
    [SerializeField] Slider BGMVolumeSlider;
    const string useKey = "BGMVolume";

    /// <summary>
    /// スクリプトのインスタンスがロードされた時に呼ばれる
    /// </summary>
    void Awake()
    {
        BGMVolumeSlider.value = PlayerPrefs.GetFloat(useKey,1f);
    }

    /// <summary>
    /// ボリュームが変更された時に呼ばれる
    /// </summary>
    public void OnChangeVolume()
    {
        var volume = BGMVolumeSlider.value;
        PlayerPrefs.SetFloat(useKey, volume);
    }
}

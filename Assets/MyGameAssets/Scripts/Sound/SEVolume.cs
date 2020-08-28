using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// SEの音量を調整する
/// </summary>
public class SEVolume : MonoBehaviour
{
    [SerializeField] Slider SEVolumeSlider;
    const string useKey = "SEVolume";

    /// <summary>
    /// スクリプトのインスタンスがロードされた時に呼ばれる
    /// </summary>
    void Awake()
    {
        SEVolumeSlider.value = PlayerPrefs.GetFloat(useKey, 1f);
    }

    /// <summary>
    /// ボリュームが変更された時に呼ばれる
    /// </summary>
    public void OnChangeVolume()
    {
        var volume = SEVolumeSlider.value;
        PlayerPrefs.SetFloat(useKey, volume);
    }
}

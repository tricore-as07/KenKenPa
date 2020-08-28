using UnityEngine;

/// <summary>
/// ゲーム開始時にBGMの音量をセットする
/// </summary>
public class BGMVolumeSetter : MonoBehaviour
{
    [SerializeField] AudioSource BGMaudioSource;
    const string useKey = "BGMVolume";

    /// <summary>
    /// オブジェクトがアクティブになった時に呼ばれる
    /// </summary>
    void OnEnable()
    {
        BGMaudioSource.volume = PlayerPrefs.GetFloat(useKey,1f);
    }
}

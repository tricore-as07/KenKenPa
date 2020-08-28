using UnityEngine;

/// <summary>
/// ゲーム開始時にBGMの音量をセットする
/// </summary>
public class SEVolumeSetter : MonoBehaviour
{
    [SerializeField] AudioSource SEaudioSource;
    const string useKey = "SEVolume";

    /// <summary>
    /// オブジェクトがアクティブになった時に呼ばれる
    /// </summary>
    void OnEnable()
    {
        SEaudioSource.volume = PlayerPrefs.GetFloat(useKey, 1f);
    }
}

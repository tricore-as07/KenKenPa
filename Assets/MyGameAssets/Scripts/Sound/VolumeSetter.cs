using UnityEngine;

//設定できるボリュームの種類
public enum VolumeKey
{
    SEVolume,
    BGMVolume
}

/// <summary>
/// ボリュームを設定する
/// </summary>
public class VolumeSetter : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;   //設定するオーディオソース
    [SerializeField] VolumeKey key;             //何のボリュームを設定するか

    /// <summary>
    /// オブジェクトがアクティブになった時に呼ばれる
    /// </summary>
    void OnEnable()
    {
        audioSource.volume = PlayerPrefs.GetFloat(key.ToString(), 1f);
    }
}

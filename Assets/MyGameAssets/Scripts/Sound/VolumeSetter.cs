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
    [SerializeField] AudioSource audioSource = default;   //設定するオーディオソース
    [SerializeField] VolumeKey key = default;             //何のボリュームを設定するか

    /// <summary>
    /// オブジェクトがアクティブになった時に呼ばれる
    /// </summary>
    void OnEnable()
    {
        audioSource.volume = PlayerPrefs.GetFloat(key.ToString(), 1f);
        VolumeAdjustment.onChangeVolumeEvent += OnChangeVolume;
    }

    /// <summary>
    /// オブジェクトが非アクティブになった時に呼ばれる
    /// </summary>
    private void OnDisable()
    {
        VolumeAdjustment.onChangeVolumeEvent -= OnChangeVolume;
    }

    /// <summary>
    /// ボリュームが変更された時に呼ばれる
    /// </summary>
    void OnChangeVolume()
    {
        audioSource.volume = PlayerPrefs.GetFloat(key.ToString(), 1f);
    }
}

using UnityEngine;
using TMPro;

/// <summary>
/// TextMeshProのマテリアルをセットする
/// </summary>
public class SetMaterialForTMP : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text = default;                              //マテリアルをセットするテキスト
    [SerializeField] Material material = default;                                 //セットするマテリアル

    /// <summary>
    /// オブジェクトがアクティブになった時に呼ばれる
    /// </summary>
    void OnEnable()
    {
        text.fontMaterial = material;
    }
}

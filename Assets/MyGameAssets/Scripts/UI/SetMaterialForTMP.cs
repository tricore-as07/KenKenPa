using UnityEngine;
using TMPro;

/// <summary>
/// TextMeshProのマテリアルをセットする
/// </summary>
public class SetMaterialForTMP : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;                                  //マテリアルをセットするテキスト
    [SerializeField] Material material;                                     //セットするマテリアル

    /// <summary>
    /// オブジェクトがアクティブになった時に呼ばれる
    /// </summary>
    void OnEnable()
    {
        text.fontMaterial = material;
    }
}

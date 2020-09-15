using UnityEngine;

/// <summary>
/// コンボアニメーションが終わった時の処理をする
/// </summary>
public class EndComboMissAnimation : MonoBehaviour
{
    /// <summary>
    /// コンボアニメーションが終わった時に処理する
    /// </summary>
    void OnEndComboMissAnimation()
    {
        gameObject.SetActive(false);
    }
}

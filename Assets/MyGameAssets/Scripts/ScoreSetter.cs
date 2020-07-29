using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// スコアをセットする
/// </summary>
public class ScoreSetter : MonoBehaviour
{
    [SerializeField] Text scoreText;
    /// <summary>
    /// オブジェクトがアクティブになった時によばれる
    /// </summary>
    void OnEnable()
    {
        scoreText.text = ProgressDistanceCounter.DistanceCounter.ToString() + "m!";
    }
}


using UnityEngine;
using TMPro;

/// <summary>
/// スコアをセットする
/// </summary>
public class ScoreSetter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;            //スコアのテキスト
    /// <summary>
    /// オブジェクトがアクティブになった時によばれる
    /// </summary>
    void OnEnable()
    {
        scoreText.text = ProgressDistanceCounter.DistanceCounter.ToString() + "m!";
    }
}


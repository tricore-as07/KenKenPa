using UnityEngine;
using TMPro;
using System.Collections.Generic;

/// <summary>
/// スコアをセットする
/// </summary>
public class ScoreSetter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText = default;                               //スコアのテキスト
    [SerializeField] List<ScoreMaterialUiSetting> scoreMaterialUiSettings = default;    //スコアによってマテリアルを設定するリスト

    /// <summary>
    /// オブジェクトがアクティブになった時によばれる
    /// </summary>
    void OnEnable()
    {
        scoreText.text = ProgressDistanceCounter.DistanceCounter.ToString();
        GameServiceUtil.ReportScore((int)ProgressDistanceCounter.DistanceCounter, 0);
        foreach (var scoreMaterialUiSetting in scoreMaterialUiSettings)
        {
            if (scoreMaterialUiSetting.ScoreNum <= ProgressDistanceCounter.DistanceCounter)
            {
                scoreText.fontMaterial = scoreMaterialUiSetting.Mat;
            }
            else
            {
                break;
            }
        }
    }
}

/// <summary>
/// スコアによってマテリアルを別々に設定する
/// </summary>
/// NOTE : orimoto ここで設定されているスコア以上で設定されているマテリアルを設定する
[System.Serializable]
public class ScoreMaterialUiSetting
{
    [SerializeField] int scoreNum = default;                        //コンボ数
    public int ScoreNum => scoreNum;                                //外部に公開するためのプロパティ
    [SerializeField] Material mat = default;                        //設定するマテリアル
    public Material Mat => mat;                                     //外部に公開するためのプロパティ
}
using UnityEngine;
using TMPro;

/// <summary>
/// スコアをセットする
/// </summary>
public class ScoreSetter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;                         //スコアのテキスト
    [SerializeField] ScoreMaterialUiSetting scoreMaterialUiSetting;
    /// <summary>
    /// オブジェクトがアクティブになった時によばれる
    /// </summary>
    void OnEnable()
    {
        scoreText.text = ProgressDistanceCounter.DistanceCounter.ToString() + "m!";
        GameServiceUtil.ReportScore((int)ProgressDistanceCounter.DistanceCounter, 0);
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
}


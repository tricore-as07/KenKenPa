using UnityEngine;

/// <summary>
/// 当たりのオブジェクトがいくつあるか把握する
/// </summary>
public class HitObjectsCounter : MonoBehaviour
{
    int hitObjectsNum;                                              //当たりのオブジェクトの数
    public bool isRightHit { get; private set; }                    //右が当たりかどうか
    public bool isCenterHit { get; private set; }                   //中央が当たりかどうか
    public bool isLeftHit { get; private set; }                     //左があたりかどうか

    /// <summary>
    /// 当たりのオブジェクトが二つの時などに同じ場所を2回押しても成功になるのを防ぐためのものです。
    /// </summary>
    bool isRightCorrect;                                            //右が当たりの時に右に対応する入力をした際にtrueになる
    bool isCenterCorrect;                                           //中央が当たりの時に中央に対応する入力をした際にtrueになる
    bool isLeftCorrect;                                             //左が当たりの時に左に対応する入力をした際にtrueになる
    [SerializeField] Transform rightObjectTransform = default;      //右のオブジェクトのTransform
    [SerializeField] Transform centerObjectTransform = default;     //中央のオブジェクトのTransform
    [SerializeField] Transform leftObjectTransform = default;       //左のオブジェクトのTransform

    /// <summary>
    /// 最初に行う処理
    /// </summary>
    void Start()
    {
        CountHitObjectsNum();
    }

    /// <summary>
    /// 当たりのオブジェクトがいくつあるか数える
    /// </summary>
    void CountHitObjectsNum()
    {
        isRightHit = rightObjectTransform.GetChild(0).tag == "HitObject";
        isCenterHit = centerObjectTransform.GetChild(0).tag == "HitObject";
        isLeftHit = leftObjectTransform.GetChild(0).tag == "HitObject";
        //当たりのオブジェクトの数をリセット
        hitObjectsNum = 0;
        if (isRightHit)
        {
            hitObjectsNum++;
        }
        if (isCenterHit)
        {
            hitObjectsNum++;
        }
        if (isLeftHit)
        {
            hitObjectsNum++;
        }
        isRightCorrect = false;
        isCenterCorrect = false;
        isLeftCorrect = false;
    }

    /// <summary>
    /// 右が当たりで選んだ時に呼ばれる
    /// </summary>
    public void OnCorrectSelectRight()
    {
        if(isRightCorrect)
        {
            return;
        }
        isRightCorrect = true;
        hitObjectsNum--;
    }

    /// <summary>
    /// 中央が当たりで選んだ時に呼ばれる
    /// </summary>
    public void OnCorrectSelectCenter()
    {
        if (isCenterCorrect)
        {
            return;
        }
        isCenterCorrect = true;
        hitObjectsNum--;
    }

    /// <summary>
    /// 左が当たりで選んだ時に呼ばれる
    /// </summary>
    public void OnCorrectSelectLeft()
    {
        if (isLeftCorrect)
        {
            return;
        }
        isLeftCorrect = true;
        hitObjectsNum--;
    }

    /// <summary>
    /// 間違ったものを選んだ時に呼ばれる
    /// </summary>
    public void OnMistakeSelect()
    {
        CountHitObjectsNum();
    }

    /// <summary>
    /// 当たりを全て選んだか
    /// </summary>
    /// <returns>Yes : true , No , false</returns>
    public bool IsAllCorrectSelect()
    {
        return (hitObjectsNum == 0);
    }

}

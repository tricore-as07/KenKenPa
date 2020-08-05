using UnityEngine;

/// <summary>
/// 入力可能かどうかでオブジェクトの見た目を変える
/// </summary>
public class InputtableIsByObjectLookChange : MonoBehaviour
{
    static InputIntervalManager inputIntervalManager;       //入力から次の入力を受け付けるまでの時間を管理する
    const int HitObject = 0;                                //子オブジェクトで入力可能時に表示するオブジェクトの要素数
    const int NotInputHitObject = 1;                        //子オブジェクトで入力不可能時に表示するオブジェクトの要素数
    const int hitObjectNum = 2;                             //当たりのオブジェクトの時の子オブジェクトの数

    /// <summary>
    /// オブジェクトが生成された直後
    /// </summary>
    void Awake()
    {
        if (inputIntervalManager == null)
        {
            inputIntervalManager = GameObject.FindGameObjectWithTag("InputIntervalManager").GetComponent<InputIntervalManager>();
        }
    }

    /// <summary>
    /// 入力可能になった時に呼ばれる
    /// </summary>
    void OnEnableIsAbleInput()
    {
        if(transform.childCount < hitObjectNum)
        {
            return;
        }
        transform.GetChild(HitObject).gameObject.SetActive(true);
        transform.GetChild(NotInputHitObject).gameObject.SetActive(false);
    }

    /// <summary>
    /// 入力可能じゃなくなった時に呼ばれる
    /// </summary>
    void OnDisableIsAbleInput()
    {
        if (transform.childCount < hitObjectNum)
        {
            return;
        }
        transform.GetChild(HitObject).gameObject.SetActive(false);
        transform.GetChild(NotInputHitObject).gameObject.SetActive(true);
    }

    /// <summary>
    /// このオブジェクトの当たり外れの判定がアクティブになったとき
    /// </summary>
    public void OnEnableCorrentCheck()
    {
        inputIntervalManager.AddOnEnableIsAbleInputFunc(OnEnableIsAbleInput);
        inputIntervalManager.AddOnDisableIsAbleInputFunc(OnDisableIsAbleInput);
    }

    /// <summary>
    /// このオブジェクトの当たり外れの判定が非アクティブになったとき
    /// </summary>
    public void OnDisableCorrentCheck()
    {
        inputIntervalManager.RemoveOnEnableIsAbleInputFunc(OnEnableIsAbleInput);
        inputIntervalManager.RemoveOnDisableIsAbleInputFunc(OnDisableIsAbleInput);
    }
}

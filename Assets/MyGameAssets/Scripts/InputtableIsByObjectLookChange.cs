using UnityEngine;

/// <summary>
/// 入力可能かどうかでオブジェクトの見た目を変える
/// </summary>
public class InputtableIsByObjectLookChange : MonoBehaviour
{
    static InputIntervalManager inputIntervalManager;       //入力から次の入力を受け付けるまでの時間を管理する
    GameObject inputtableObject;                            //入力可能な時のオブジェクト
    GameObject notInputtableObject;                         //入力不可能な時のオブジェクト
    const int InputtableObject = 0;                         //子オブジェクトで入力可能時に表示するオブジェクトの要素数
    const int NotInputtableObject = 1;                      //子オブジェクトで入力不可能時に表示するオブジェクトの要素数
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
        inputtableObject.SetActive(true);
        notInputtableObject.SetActive(false);
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
        inputtableObject.SetActive(true);
        notInputtableObject.SetActive(false);
    }

    /// <summary>
    /// このオブジェクトの当たり外れの判定がアクティブになったとき
    /// </summary>
    public void OnEnableCorrentCheck()
    {
        inputIntervalManager.AddOnEnableIsAbleInputFunc(OnEnableIsAbleInput);
        inputIntervalManager.AddOnDisableIsAbleInputFunc(OnDisableIsAbleInput);
        bool isHitObject = transform.childCount >= hitObjectNum;        //当たりのオブジェクトかどうか
        if (isHitObject)
        {
            inputtableObject = transform.GetChild(InputtableObject).gameObject;
            notInputtableObject = transform.GetChild(NotInputtableObject).gameObject;
        }
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

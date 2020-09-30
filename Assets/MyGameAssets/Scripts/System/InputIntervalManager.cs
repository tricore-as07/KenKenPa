using UnityEngine;
using System;

/// <summary>
/// 入力から次の入力を受け付けるまでの時間を管理する
/// </summary>
public class InputIntervalManager : MonoBehaviour
{
    public bool isAbleInput { get; private set; }                                   //入力可能かどうか
    event Action onEnableIsAbleInputFunc;                                           //入力可能になった時に呼ばれる関数
    event Action onDisableIsAbleInputFunc;                                          //入力不可能になった時に呼ばれる関数

    /// <summary>
    /// オブジェクトがアクティブになった時によばれる
    /// </summary>
    void OnEnable()
    {
        isAbleInput = true;
        onEnableIsAbleInputFunc?.Invoke();
    }

    /// <summary>
    /// 毎フレーム行う処理
    /// </summary>
    void Update()
    {
        //入力を受け付けてない時
        if (!isAbleInput)
        {
            //入力を可能にする
            isAbleInput = true;
            onEnableIsAbleInputFunc?.Invoke();
        }
    }

    /// <summary>
    /// 入力した時に呼ぶ
    /// </summary>
    public void OnInput()
    {
        isAbleInput = false;
        onDisableIsAbleInputFunc?.Invoke(); ;
    }

    /// <summary>
    /// 入力ミスした時に呼ぶ
    /// </summary>
    public void MissInput()
    {
        isAbleInput = false;
        onDisableIsAbleInputFunc?.Invoke();
    }

    /// <summary>
    /// 入力可能になった時に呼ばれる関数を追加する
    /// </summary>
    /// <param name="action">追加する関数</param>
    public void AddOnEnableIsAbleInputFunc(Action action)
    {
        onEnableIsAbleInputFunc += action;
    }

    /// <summary>
    /// 入力可能になった時に呼ばれる関数を削除する
    /// </summary>
    /// <param name="action">削除する関数</param>
    public void RemoveOnEnableIsAbleInputFunc(Action action)
    {
        onEnableIsAbleInputFunc -= action;
    }

    /// <summary>
    /// 入力不可能になった時に呼ばれる関数を追加する
    /// </summary>
    /// <param name="action">追加する関数</param>
    public void AddOnDisableIsAbleInputFunc(Action action)
    {
        onDisableIsAbleInputFunc += action;
    }

    /// <summary>
    /// 入力不可能になった時に呼ばれる関数を削除する
    /// </summary>
    /// <param name="action">削除する関数</param>
    public void RemoveOnDisableIsAbleInputFunc(Action action)
    {
        onDisableIsAbleInputFunc -= action;
    }
}

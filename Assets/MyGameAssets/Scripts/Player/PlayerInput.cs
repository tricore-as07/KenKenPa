using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム中のプレイヤーの入力に関するクラス
/// </summary>
public class PlayerInput : MonoBehaviour
{
    bool rightInput;
    bool centerInput;
    bool leftInput;

    InputAction inputAction;

    /// <summary>
    /// 最初に行う処理
    /// </summary>
    void Start()
    {
        inputAction = GetComponent<InputAction>();
    }

    /// <summary>
    /// 毎フレーム行う処理
    /// </summary>
    void Update()
    {
        UpdateInput();

        if(rightInput)
        {
            inputAction.IsRightInputted();
        }

        if(centerInput)
        {
            inputAction.IsCenterInputted();
        }

        if (leftInput)
        {
            inputAction.IsLeftInputted();
        }

    }

    /// <summary>
    /// 入力を元に必要な変数を更新する
    /// </summary>
    void UpdateInput()
    {
        rightInput = Input.GetKeyDown(KeyCode.D);

        centerInput = Input.GetKeyDown(KeyCode.S);

        leftInput = Input.GetKeyDown(KeyCode.A);
    }
}

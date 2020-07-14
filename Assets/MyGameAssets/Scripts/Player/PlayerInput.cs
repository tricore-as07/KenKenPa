using UnityEngine;

/// <summary>
/// ゲーム中のプレイヤーの入力に関するクラス
/// </summary>
public class PlayerInput : MonoBehaviour
{
    bool rightInput;            //右に対応する入力されたかどうか
    bool centerInput;           //中央に対応する入力されたかどうか
    bool leftInput;             //左に対応する入力されたかどうか
    InputAction inputAction;    //入力があった時に実際の処理をするクラス

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
            inputAction.OnRightInput();
        }
        if(centerInput)
        {
            inputAction.OnCenterInput();
        }
        if (leftInput)
        {
            inputAction.OnLeftInput();
        }
    }

    /// <summary>
    /// 入力を元に必要な変数を更新する
    /// </summary>
    void UpdateInput()
    {
#if UNITY_EDITOR
        rightInput = Input.GetKeyDown(KeyCode.D);
        centerInput = Input.GetKeyDown(KeyCode.S);
        leftInput = Input.GetKeyDown(KeyCode.A);
#endif
        //タップ入力の数だけループ
        foreach (Touch touch in Input.touches)
        {
            //タップされた時
            if(touch.phase == TouchPhase.Began)
            {
                //下半分の画面で判定する
                if (touch.position.y <= Screen.height / 2)
                {
                    rightInput = touch.position.x >= (Screen.width / 3 * 2);
                    centerInput = touch.position.x >= (Screen.width / 3) && touch.position.x <= (Screen.width / 3 * 2);
                    leftInput = touch.position.x <= (Screen.width / 3);
                }
            }
        }
    }
}

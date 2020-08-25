using UnityEngine;
using System.Collections;

/// <summary>
/// ゲーム中のプレイヤーの入力に関するクラス
/// </summary>
public class PlayerInput : MonoBehaviour
{
    bool rightInput;                                    //右に対応する入力されたかどうか
    bool centerInput;                                   //中央に対応する入力されたかどうか
    bool leftInput;                                     //左に対応する入力されたかどうか
    [SerializeField] Transform rightObj = default;      //右のタップを判定する中心
    [SerializeField] Transform centerObj = default;     //中央のタップを判定する中心
    [SerializeField] Transform leftObj = default;       //左のタップを判定する中心
    [SerializeField] float tapRange = default;          //タップの判定の大きさ
    [SerializeField] new Camera camera = default;       //カメラ
    InputAction inputAction;                            //入力があった時に実際の処理をするクラス
    [SerializeField] float sideInputIntervalTime = default;
    float sideInputDistSetting;
    bool isSideInputInterval;
    Vector2 sideInputPos;

    /// <summary>
    /// 最初に行う処理
    /// </summary>
    void Start()
    {
        inputAction = GetComponent<InputAction>();
        sideInputDistSetting = Screen.width / 5;
    }

    /// <summary>
    /// 毎フレーム行う処理
    /// </summary>
    void Update()
    {
#if UNITY_EDITOR
        UpdateInput();
        if (rightInput)
        {
            inputAction.OnRightInput();
        }
        if (centerInput)
        {
            inputAction.OnCenterInput();
        }
        if (leftInput)
        {
            inputAction.OnLeftInput();
        }
#endif
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

    /// <summary>
    /// オブジェクトがアクティブになった時に呼ばれる
    /// </summary>
    void OnEnable()
    {
        IT_Gesture.onMultiTapE += OnMultiTap;
        isSideInputInterval = false;
    }

    /// <summary>
    /// オブジェクトが非アクティブになった時に呼ばれる
    /// </summary>
    void OnDisable()
    {
        IT_Gesture.onMultiTapE -= OnMultiTap;
    }

    /// <summary>
    /// タップされた時によばれる
    /// </summary>
    /// <param name="tap">タップに関する情報</param>
    void OnMultiTap(Tap tap)
    {
        ////右がタップ入力されているか
        //if (IsTapInput(tap.pos,rightObj.position))
        //{
        //    inputAction.OnRightInput();
        //}
        ////中央がタップ入力されているか
        //if (IsTapInput(tap.pos, centerObj.position))
        //{
        //    inputAction.OnCenterInput();
        //}
        ////左がタップ入力されているか
        //if (IsTapInput(tap.pos, leftObj.position))
        //{
        //    inputAction.OnLeftInput();
        //}

        if(isSideInputInterval)
        {
            float inputDist = sideInputPos.x - tap.pos.x;
            if(inputDist > sideInputDistSetting)
            {
                inputAction.OnLeftInput();
                inputAction.OnRightInput();
                isSideInputInterval = false;
                return;
            }
        }
        if(Screen.width / 3 < tap.pos.x && tap.pos.x < Screen.width / 3 * 2)
        {
            inputAction.OnCenterInput();
        }
        else
        {
            isSideInputInterval = true;
            sideInputPos = tap.pos;
        }
    }

    /// <summary>
    /// タップ入力されているかどうか
    /// </summary>
    /// <param name="tapPos">タップされたポジション</param>
    /// <param name="objPos">入力を判定するオブジェクトのポジション</param>
    /// <returns>入力されている : true,入力されていない : false</returns>
    bool IsTapInput(Vector2 tapPos,Vector3 objPos)
    {
        //オブジェクトのカメラ上での位置
        var pos = RectTransformUtility.WorldToScreenPoint(camera, objPos);
        //タップした位置がオブジェクトからの一定範囲内なら
        if ((pos - tapPos).sqrMagnitude < tapRange * tapRange)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// サイド入力がされた時に呼ばれるコルーチン
    /// </summary>
    /// <returns></returns>
    private IEnumerator OnSideInput()
    {
        yield return new WaitForSeconds(sideInputIntervalTime);
        isSideInputInterval = false;
    }
}

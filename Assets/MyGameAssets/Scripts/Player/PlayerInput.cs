using UnityEngine;
using System.Collections;

/// <summary>
/// ゲーム中のプレイヤーの入力に関するクラス
/// </summary>
public class PlayerInput : MonoBehaviour
{
    bool rightInput;                                        //右に対応する入力されたかどうか
    bool centerInput;                                       //中央に対応する入力されたかどうか
    bool leftInput;                                         //左に対応する入力されたかどうか
    [SerializeField] new Camera camera = default;           //カメラ
    InputAction inputAction;                                //入力があった時に実際の処理をするクラス
    [SerializeField] float sideInputIntervalTime = default; //左右入力のズレの許容時間
    float sideInputDistSetting;                             //左右入力の間の最低距離
    bool isSideInputInterval;                               //左右入力のズレの許容時間内かどうか
    Coroutine sideInputCoroutine;                           //左右入力のズレの許容時間を待つ用のコルーチン
    bool hasReleasedAfterInput;

    /// <summary>
    /// 最初に行う処理
    /// </summary>
    void Start()
    {
        inputAction = GetComponent<InputAction>();
        //画面の横幅の５分の１は左右入力で間を開けるように設定
        sideInputDistSetting = Screen.width / 5;
    }

    /// <summary>
    /// 毎フレーム行う処理
    /// </summary>
    void Update()
    {
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
        //入力された後に指が離されたかどうか
        if(!hasReleasedAfterInput)
        {
            if(Input.touchCount == 0)
            {
                hasReleasedAfterInput = true;
            }
            else
            {
                return;
            }
        }
        if (Input.touchCount == 1)
        {
            Touch touch = Input.touches[0];
            bool isTapCenter = Screen.width / 3 < touch.position.x && touch.position.x < Screen.width / 3 * 2;
            //入力された場所が中央なら
            if (isTapCenter)
            {
                inputAction.OnCenterInput();
                hasReleasedAfterInput = false;
            }
        }
        else if(Input.touchCount == 2)
        {
            Touch firstTouch = Input.touches[0];
            Touch secondTouch = Input.touches[1];
            float inputDist = Mathf.Abs(firstTouch.position.x - secondTouch.position.x);
            if (inputDist > sideInputDistSetting)
            {
                //左右の入力をオンにする
                inputAction.OnLeftInput();
                inputAction.OnRightInput();
                isSideInputInterval = false;
                hasReleasedAfterInput = false;
                StopCoroutine(sideInputCoroutine);
                return;
            }
        }
    }

    /// <summary>
    /// オブジェクトがアクティブになった時に呼ばれる
    /// </summary>
    void OnEnable()
    {
        isSideInputInterval = false;
        hasReleasedAfterInput = true;
    }

    /// <summary>
    /// 中央入力でミスだった場合にサイド入力かどうか誤差許容時間だけ待つ
    /// </summary>
    /// <returns></returns>
    public IEnumerator WaitSideInput()
    {
        isSideInputInterval = true;
        yield return new WaitForSeconds(sideInputIntervalTime);
        if(!isSideInputInterval)
        {
            yield break;
        }
        hasReleasedAfterInput = true;
        isSideInputInterval = false;
        inputAction.OnCenterInputMiss();
    }

    /// <summary>
    /// サイド入力判定をするときのコルーチンをセットする
    /// </summary>
    /// <param name="coroutine">セットするコルーチン</param>
    public void SetSideInputCoroutine(Coroutine coroutine)
    {
        sideInputCoroutine = coroutine;
    }
}

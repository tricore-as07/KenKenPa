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
    [SerializeField] float sideInputIntervalTime = default; //左右入力のズレの許容時間
    InputAction inputAction;                                //入力があった時に実際の処理をするクラス
    bool isSideInputInterval;                               //左右入力のズレの許容時間内かどうか
    Coroutine sideInputCoroutine;                           //左右入力のズレの許容時間を待つ用のコルーチン
    bool hasReleasedAfterInput;                             //入力したあと離したかどうか
    const int sideInputDistOfScreenSplitNum = 5;            //左右入力の間隔を画面の分割数で表したもの
    static readonly int leftWidth = Screen.width / 3;       //画面の左側かどうかを区別するライン（画面の横幅の３分の１より小さい値なら左側）
    static readonly int rightWidth = Screen.width / 3 * 2;  //画面の右側かどうかを区別するライン（画面の横幅の３分の２より大きい値なら右側）
    static readonly float sideInputDistSetting              //左右入力の間隔
        = Screen.width / sideInputDistOfScreenSplitNum;

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
        //入力された後に指が離されたかどうか
        if (!hasReleasedAfterInput)
        {
            if (Input.touchCount == 0)
            {
                hasReleasedAfterInput = true;
            }
            else
            {
                //入力された後に指が離されていない場合は次の入力を受け付けないため早期リターン
                return;
            }
        }
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
        //タップされた指が１本のとき
        if (Input.touchCount == 1)
        {
            Touch touch = Input.touches[0];
            bool isTapCenter = leftWidth < touch.position.x && touch.position.x < rightWidth;
            //入力された場所が中央なら
            if (isTapCenter)
            {
                inputAction.OnCenterInput();
                hasReleasedAfterInput = false;
            }
        }
        //タップされた指が２本のとき
        else if (Input.touchCount == 2)
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
                if(sideInputCoroutine != null)
                {
                    StopCoroutine(sideInputCoroutine);
                    sideInputCoroutine = null;
                }
            }
        }
    }

    /// <summary>
    /// オブジェクトがアクティブになった時に呼ばれる
    /// </summary>
    void OnEnable()
    {
        isSideInputInterval = false;
    }

    /// <summary>
    /// オブジェクトが非アクティブになった時に呼ばれる
    /// </summary>
    void OnDisable()
    {
        hasReleasedAfterInput = false;
    }

    /// <summary>
    /// 中央入力でミスだった場合にサイド入力かどうか誤差許容時間だけ待つ
    /// </summary>
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

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
    [SerializeField] float tapRange = default;          //タップの判定の大きさ
    [SerializeField] new Camera camera = default;       //カメラ
    InputAction inputAction;                            //入力があった時に実際の処理をするクラス
    [SerializeField] float sideInputIntervalTime = default; //左右入力のズレの許容時間
    float sideInputDistSetting;                             //左右入力の間の最低距離
    bool isSideInputInterval;                               //左右入力のズレの許容時間内かどうか
    Vector2 sideInputPos;                                   //左右入力の早かった方のポジション
    Coroutine sideInputCoroutine;                           //左右入力のズレの許容時間を待つ用のコルーチン

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
        //左右入力のズレの許容時間内なら
        if(isSideInputInterval)
        {
            float inputDist = sideInputPos.x - tap.pos.x;   //左右入力の横幅の間隔
            //左右入力の横幅の間隔が設定された距離より空いていれば
            if(inputDist > sideInputDistSetting)
            {
                //左右の入力をオンにする
                inputAction.OnLeftInput();
                inputAction.OnRightInput();
                isSideInputInterval = false;
                StopCoroutine(sideInputCoroutine);
                return;
            }
        }
        bool isTapCenter = Screen.width / 3 < tap.pos.x && tap.pos.x < Screen.width / 3 * 2;
        sideInputPos = tap.pos;
        //入力された場所が中央なら
        if (isTapCenter)
        {
            inputAction.OnCenterInput();
        }
        //入力された場所が中央じゃなければ
        else
        {
            isSideInputInterval = true;
            sideInputCoroutine = StartCoroutine(OnSideInput());
        }
    }

    /// <summary>
    /// サイド入力がされた時に呼ばれるコルーチン
    /// </summary>
    /// <returns></returns>
    IEnumerator OnSideInput()
    {
        yield return new WaitForSeconds(sideInputIntervalTime);
        //入力のズレの許容時間が過ぎたら
        isSideInputInterval = false;
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
        isSideInputInterval = false;
        inputAction.OnCenterInputMiss();
    }
}

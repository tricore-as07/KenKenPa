using UnityEngine;

/// <summary>
/// ゲーム中のプレイヤーの入力に関するクラス
/// </summary>
public class PlayerInput : MonoBehaviour
{
    bool rightInput;            //右に対応する入力されたかどうか
    bool centerInput;           //中央に対応する入力されたかどうか
    bool leftInput;             //左に対応する入力されたかどうか
    [SerializeField] Transform rightObj = default;
    [SerializeField] Transform centerObj = default;
    [SerializeField] Transform leftObj = default;
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
#if UNITY_EDITOR
        UpdateInput();
#endif
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
    }

    /// <summary>
    /// オブジェクトが非アクティブになった時に呼ばれる
    /// </summary>
    void OnDisable()
    {
        IT_Gesture.onMultiTapE -= OnMultiTap;
    }

    void OnMultiTap(Tap tap)
    {
        Ray ray = Camera.main.ScreenPointToRay(tap.pos);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,Mathf.Infinity))
        {
            if(hit.collider.transform == rightObj)
            {
                inputAction.OnRightInput();
            }
            if (hit.collider.transform == centerObj)
            {
                inputAction.OnCenterInput();
            }
            if (hit.collider.transform == leftObj)
            {
                inputAction.OnLeftInput();
            }
        }
    }
    
}

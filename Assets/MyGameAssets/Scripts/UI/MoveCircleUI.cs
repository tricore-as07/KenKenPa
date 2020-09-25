using UnityEngine;

/// <summary>
/// 丸を動かす
/// </summary>
public class MoveCircleUI : MonoBehaviour
{
    [SerializeField] float moveTime = default;      //画面の下から上まで動くのにかかる時間
    float moveSpeed = default;                      //動くスピード
    float halfScreenHeight = default;               //画面の半分の大きさ

    /// <summary>
    /// 最初に行う処理
    /// </summary>
    void Start()
    {
        moveSpeed = Screen.height / moveTime;
        halfScreenHeight = Screen.height / 2;
    }

    /// <summary>
    /// 毎フレーム行う処理
    /// </summary>
    void Update()
    {
        //左に自分を動かす
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;

        //画面から画面の半分以上左にあるなら
        if (transform.position.y > Screen.height + halfScreenHeight)
        {
            //画面右端から画面の半分右に動かす
            transform.position += Vector3.down * (Screen.height * 2);
        }
    }
}

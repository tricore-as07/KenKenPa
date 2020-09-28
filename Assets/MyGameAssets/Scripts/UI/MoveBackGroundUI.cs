using UnityEngine;

/// <summary>
/// 背景UIを動かす
/// </summary>
public class MoveBackGroundUI : MonoBehaviour
{
    [SerializeField] float moveTime = default;      //画面の右端から左端まで動くのにかかる時間
    float moveSpeed = default;                      //動くスピード
    float halfScreenWidth = default;                //画面の半分の大きさ

    /// <summary>
    /// 最初に行う処理
    /// </summary>
    void Start()
    {
        moveSpeed = Screen.width / moveTime;
        halfScreenWidth = Screen.width / 2;
    }

    /// <summary>
    /// 毎フレーム行う処理
    /// </summary>
    void Update()
    {
        //左に自分を動かす
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        //画面左端から画面の半分以上左にあるなら
        if (transform.position.x < -halfScreenWidth)
        {
            //画面右端から画面の半分右に動かす
            transform.position = Vector3.right * (Screen.width + halfScreenWidth);
            //Y座標を画面の中心に戻す
            transform.position += Vector3.up * Screen.height / 2;
        }
    }
}

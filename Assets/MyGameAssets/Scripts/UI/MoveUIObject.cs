using UnityEngine;

public class MoveUIObject : MonoBehaviour
{
    [SerializeField] float moveTime = default;
    float moveSpeed = default;

    void Start()
    {
        moveSpeed = Screen.width / moveTime; 
    }

    /// <summary>
    /// 毎フレーム行う処理
    /// </summary>
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        if(transform.position.x < -Screen.width / 2)
        {
            transform.position = Vector3.right * Screen.width * 1.5f;
            transform.position += Vector3.up * Screen.height / 2;
        }
    }
}

using UnityEngine;

/// <summary>
/// アタッチしている背景オブジェクトが必要なくなった時に削除する
/// </summary>
public class BackgroundDeleter : MonoBehaviour
{
    static GameObject player;
    static StageCreater stageCreater;

    /// <summary>
    /// 最初に行う処理
    /// </summary>
    void Start()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if(stageCreater == null)
        {
            stageCreater = GameObject.FindGameObjectWithTag("StageCreater").GetComponent<StageCreater>();
        }
    }

    /// <summary>
    /// 毎フレーム行う処理
    /// </summary>
    void Update()
    {
        if(player.transform.position.z > transform.position.z)
        {
            stageCreater.CreateBackground();
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// オブジェクトが非アクティブになった時によばれる
    /// </summary>
    void OnDisable()
    {
        Destroy(gameObject);
    }
}

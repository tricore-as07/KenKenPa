using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 入力があった際の動作をするクラス
/// </summary>
public class InputAction : MonoBehaviour
{

    bool canInput;
    HitCheck hitCheck;
    List<GameObject> ObjectsGroupList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        ObjectsGroupList.AddRange(GameObject.FindGameObjectsWithTag("ObjectsGroup"));
        // オブジェクトグループを近い順にソート
        ObjectsGroupList.Sort((a,b) => (int)(
            (Vector3.Distance(a.transform.position,transform.position)) -
            (Vector3.Distance(a.transform.position, transform.position))
            ) );
        hitCheck = ObjectsGroupList[0].GetComponent<HitCheck>();
        canInput = true;
    }

    /// <summary>
    /// 右が入力された時
    /// </summary>
    public void IsRightInputted()
    {
        if(canInput)
        {
            var isHit = hitCheck.IsRightHit();
            if(isHit)
            {
                hitCheck.
            }
        }
    }

    /// <summary>
    /// 中央が入力された時
    /// </summary>
    public void IsCenterInputted()
    {
        if (canInput)
        {
            var isHit = hitCheck.IsCenterHit();
            if (isHit)
            {

            }
        }
    }

    /// <summary>
    /// 左が入力された時
    /// </summary>
    public void IsLeftInputted()
    {
        if (canInput)
        {
            var isHit = hitCheck.IsLeftHit();
            if (isHit)
            {

            }
        }
    }

}

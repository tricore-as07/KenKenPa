using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 子のオブジェクトとタグを合わせる
/// </summary>
public class MatchTag : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        tag = transform.GetChild(0).tag;
    }
}

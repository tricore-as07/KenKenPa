using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InputIntervalSettingData : ScriptableObject
{
    public List<InputIntervalSetting> inputIntervalSettings = new List<InputIntervalSetting>();
} 

[System.Serializable]
public class InputIntervalSetting
{
    [SerializeField]
    int ComboNum;
    [SerializeField]
    float intervalTime;

}

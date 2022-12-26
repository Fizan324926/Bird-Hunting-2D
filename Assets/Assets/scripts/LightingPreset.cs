using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName ="lightening presere",menuName ="lightening preset",order =1)]
public class LightingPreset : ScriptableObject
{
    public Gradient ambiant_color;
    public Gradient directtional_color;
    public Gradient fog_color;
    

}

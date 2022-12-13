using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName ="Reagent")]
public class Reagant : ScriptableObject
{
    public ReagantType type;
    public Sprite sprite;
    public int ID;

    
}

public enum ReagantType
{
    Oxide,
    Metal,
    Filler
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName ="Dialogue")]
public class Dialogue : ScriptableObject
{
    public string Title;
    [TextArea(3,10)]
    public string[] Sentences;

  

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageDisplayer : MonoBehaviour
{
    Text text;
    public float displayTime = 5f;


    private void Awake()
    {
        text = GetComponent<Text>();
        text.text = "Hello there";
        
    }



    public IEnumerator DisplayMessage(string message)
    {
        text.text = message;
        new WaitForSeconds(displayTime);
        text.text = "";
        return null;
    }
}

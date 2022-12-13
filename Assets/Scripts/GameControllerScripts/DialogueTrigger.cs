using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(TriggerMeScotty))]
public class DialogueTrigger : MonoBehaviour
{
    
    public Dialogue dialogue;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            StartDialogue();
            Debug.Log("It Got this far...");
        }
    }




    public void StartDialogue()
    {
        DialogueManager.Instance.DisplayDialog(this.dialogue);
    }

}

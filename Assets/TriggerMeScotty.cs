using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMeScotty : MonoBehaviour
{

    DialogueTrigger trigger;
    bool hasBeenTriggerd = false;
    public TriggerType triggerType;

    private void Awake()
    {
        trigger = GetComponent<DialogueTrigger>();
    }
    private void Start()
    {
        if(triggerType == TriggerType.SceneStart)
        {
            Debug.Log("It should be working");
            trigger.StartDialogue();
            Debug.Log("But it isnt");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(triggerType == TriggerType.Collision)
        {
            

            if (trigger != null && !hasBeenTriggerd)
            {
                trigger.StartDialogue();
                hasBeenTriggerd = true;
            }
        }
        
    }


}
public enum TriggerType
{
    Collision,
    Button,
    ScriptCall,
    SceneStart

}

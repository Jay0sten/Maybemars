using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [HideInInspector]
    public static DialogueManager Instance;

    [Header("Components")]
    GameController gameController;
    public GameObject dialogueBox;
    public Queue<string> dialogueList;
    Text text;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        gameController = FindObjectOfType<GameController>();
        dialogueList = new Queue<string>();
        text = dialogueBox.GetComponentInChildren<Text>();
    }
    private void Start()
    {
        dialogueBox.SetActive(false);
    }
    private void Update()
    {
        
    }


    public void DisplayDialog(Dialogue dialogue)
    {
        dialogueBox.SetActive(true);
        dialogueList.Clear();
        foreach (string sentence in dialogue.Sentences)
        {
            dialogueList.Enqueue(sentence);
        }
        
        text.text = dialogueList.Dequeue();
    }




    public void DisplayNextSentence()
    {
        if(dialogueList.Count == 0)
        {
            EndDialogue();
            return;
        }
        text.text = dialogueList.Dequeue();

        
    }


    public void EndDialogue()
    {
        dialogueBox.SetActive(false );
    }

   





}

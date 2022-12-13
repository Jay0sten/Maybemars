using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Components")]
    public WitchyControls controls;
    public Text pause;
    [SerializeField] GameObject exitButton;
    public Dialogue StartScene;
    [SerializeField] private bool isPaused = false;

    private void Awake()
    {
        controls = new WitchyControls();
        pause.enabled = false;
        exitButton.SetActive(false);
        
    }
    
    void Start()
    {
        if(StartScene != null)
        {
            DialogueManager.Instance.DisplayDialog(StartScene);
        }
        

    }

    
    void Update()
    {
        if(controls.Player.MenuButton.WasPressedThisFrame())
        {
            Time.timeScale = isPaused ? 1f : 0f;
            isPaused = !isPaused;
            pause.enabled = !pause.enabled;
            exitButton.active = !exitButton.active;
        }
    }


    //Public Methods

    public void Quit()
    {
        Application.Quit();
    }

    //Enable and Disable Scripts

    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }

  
}

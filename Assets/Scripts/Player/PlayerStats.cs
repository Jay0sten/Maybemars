using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Header("Basic Stats")]
    [SerializeField] private float MaxOxygen;
    [SerializeField] private float Oxygen;
    [SerializeField] private float MaxHealth;
    [SerializeField] private float Health;

    [Header("Components")]
    public StatBar OxygenStatBar;


    
    
    private void Awake()
    {
        Oxygen = MaxOxygen;
        Health = MaxHealth;
        OxygenStatBar.SetValue(Oxygen);
    }

    private void Update()
    {
        

    }
}

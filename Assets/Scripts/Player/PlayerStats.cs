using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Header("Basic Stats")]
    [SerializeField] private float MaxOxygen;
    [SerializeField] public  float Oxygen;
    [SerializeField] private float MaxHealth;
    [SerializeField] private float Health;

    [Header("Components")]
    public StatBar OxygenStatBar;
    public StatBar HealthStatBar;


    
    
    private void Awake()
    {
        Oxygen = MaxOxygen;
        Health = MaxHealth;
        OxygenStatBar.SetValue(Oxygen);
        HealthStatBar.SetValue(Health);
    }

    private void Update()
    {
        if(Oxygen <= 0)
        {
            Die();
        }

    }

    public void Die()
    {
        Debug.Log("You Died...");
    }
}

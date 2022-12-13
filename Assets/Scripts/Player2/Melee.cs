using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
public class Melee : MonoBehaviour
{

    InputActionAsset inputActions;
    InputActionMap inputActionsMap;
    Animator animator;
    public float MaxAttackSpeed = 2f;
    float attackSpeed = 0f;

    public AudioSource hitnoise;

    public Transform AttackPoint;
    public float AttackRadius = 0.46f;
    public int Damage;

    bool hasAttacked = false;
    int numberofattacksmade = 0;


    private void Awake()
    {
        inputActions = this.GetComponent<PlayerInput>().actions;
        inputActionsMap = inputActions.FindActionMap("Player");
        animator = this.GetComponent<Animator>();
        MaxAttackSpeed = 2f;
    }

    private void Update()
    {
       

      
        
        

    }

    
    void OnFire()
    {
        if(Time.time >= attackSpeed)
        {
            
            Attack();
           attackSpeed = Time.time + 1f / MaxAttackSpeed;  
            
            numberofattacksmade++;

        }
        
        

    }
    

    void Attack()
    {
        animator.SetTrigger("Attack");
        hitnoise.Play();
        attackSpeed = Time.time + 1f / MaxAttackSpeed;
        Collider2D[] hits = Physics2D.OverlapCircleAll(AttackPoint.position,AttackRadius);
        

        foreach(Collider2D hit in hits)
        {
            
           Damagable damagable = hit.GetComponent<Damagable>();
           if(damagable != null)
            {
                Debug.Log(hit.gameObject.name);
                damagable.TakeDamage(1);
            }
        }
        return;
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRadius);
    }
}

   

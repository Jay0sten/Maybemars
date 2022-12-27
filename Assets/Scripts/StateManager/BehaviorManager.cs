using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;


public class BehaviorManager : StateMachine
{
    //Components
    [SerializeField] public Transform[] _points;
    public Rigidbody2D _rb;
    [HideInInspector] public Animator _animator;

    //Fields
    [SerializeField] public float _speed = 20;
    [SerializeField] public float _maxSpeed = 18;
    public float _MovementX;
    [HideInInspector] public bool _facingRight;

    //Engaging
    public Transform target;
    public float _lookRadius;
    public Collider2D[] sightsToSee;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
        SetState(new Patrolling(this));
        _rb = GetComponent<Rigidbody2D>();
    }

   

    private void Update()
    {
        
        
        state.Active();
        
        
    
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            Debug.Log("I smell you");
            PlayerController playerCon = other.GetComponent<PlayerController>();
            playerCon.TakeKnockback(5000, 100, other.transform);
            other.GetComponent<PlayerStats>().TakeDamage(5);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

       if(_points.Length > 0)
        {
            for (int i = 0; i < _points.Length; i++)
            {
                Gizmos.DrawWireSphere(_points[i].position, .5f);
            }



        }

        Gizmos.DrawWireSphere(transform.position, _lookRadius);
        
        
        
    }

     

   
        

    



}

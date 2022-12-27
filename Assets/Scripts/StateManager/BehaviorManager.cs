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

    //Fields
    [SerializeField] public float _speed = 20;
    [SerializeField] public float _maxSpeed = 18;
    public float _MovementX;

    //Engaging
    public Transform target;
    public float _lookRadius;
    public Collider2D[] sightsToSee;


    private void Awake()
    {
        SetState(new Patrolling(this));
        _rb = GetComponent<Rigidbody2D>();
    }

   

    private void Update()
    {
        
        
        state.Active();
        
        
       
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

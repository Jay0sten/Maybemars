using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : State
{

    float _lookTime = 1.5f;
   
    float _maxLookTime = 1.5f;

    float _speed;

    int _index;



    public Patrolling(BehaviorManager behaviorManager) : base(behaviorManager)
    {



    }
    public override IEnumerator Start()
    {
    
        _speed = 2.5f;
        _index = 1;
        behaviorManager.transform.position = behaviorManager._points[0].position;
        
        return base.Start();
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
    }
    public override void Active()
    {
        checkForPlayer();
        if (behaviorManager.transform.position.x == behaviorManager._points[_index].position.x)
        {
          updateIndex();
            
            

        }
        behaviorManager.transform.position = Vector3.MoveTowards(behaviorManager.transform.position, behaviorManager._points[_index].position, _speed * Time.deltaTime);
       
        


       
        
        base.Active();
    }
    void updateIndex()
    {
       
        if (_index == behaviorManager._points.Length - 1)
        {
            _index = 0;
        }
        else { _index++; }
        Debug.Log("I changed the index to " + _index);
    }

    private void checkForPlayer()
    {
        _lookTime -= Time.deltaTime;
        
        if(_lookTime <= 0)
        {
            behaviorManager.sightsToSee = Physics2D.OverlapCircleAll(behaviorManager.transform.position, behaviorManager._lookRadius);
            if(behaviorManager.sightsToSee.Length > 0)
            {
                for (int i = 0; i < behaviorManager.sightsToSee.Length; i++)
                {
                    if(behaviorManager.sightsToSee[i].CompareTag("Player"))
                    {
                        behaviorManager.target = behaviorManager.sightsToSee[i].transform;
                        behaviorManager.SetState(new SimpleEngage(behaviorManager));

                    }
                }
               

            }
            _lookTime = _maxLookTime;  
        }

    }


}

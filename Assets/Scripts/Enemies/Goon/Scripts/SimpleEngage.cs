using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEngage : State
{
    float _speed;
    

    public SimpleEngage(BehaviorManager behaviorManager) : base(behaviorManager)
    {


    }
    public override IEnumerator Start()
    {
        _speed = 5;
        return base.Start();
    }
    public override void StateUpdate()
    {

        base.StateUpdate();
    }
    public override void Active()
    {


        behaviorManager.transform.position = Vector3.MoveTowards(behaviorManager.transform.position, behaviorManager.target.position, _speed * Time.deltaTime);
        base.Active();
    }
   
    



}

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
        if(behaviorManager.target.position.x > behaviorManager.transform.position.x) {  behaviorManager._facingRight = true; } else { behaviorManager._facingRight = false; }

        behaviorManager.transform.position = Vector3.MoveTowards(behaviorManager.transform.position, behaviorManager.target.position, _speed * Time.deltaTime);
        behaviorManager.transform.rotation = behaviorManager._facingRight ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
        base.Active();
    }
   
    



}

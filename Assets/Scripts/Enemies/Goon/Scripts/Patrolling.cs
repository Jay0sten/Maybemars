using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : State
{
    public Patrolling(BehaviorManager behaviorManager) : base(behaviorManager)
    {



    }
    public override IEnumerator Start()
    {

        return base.Start();
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
    }
    public override void Active()
    {
        Debug.Log("Its Working");
        if(Input.GetKey(KeyCode.Z))
        {
            behaviorManager._MovementX = 1;



        }
        else
        {
            behaviorManager._MovementX = 0;
        }
        Vector3 MoveMe = new Vector3(behaviorManager._MovementX * behaviorManager._speed * Time.deltaTime, 0, 0);
        behaviorManager._rb.AddForce(MoveMe);
        base.Active();
    }





}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected BehaviorManager behaviorManager;

    

    public State(BehaviorManager _behaviorManager)
    {
        behaviorManager = _behaviorManager;
    }

    public virtual IEnumerator Start()
    {
        
        yield break;
    }

   public virtual void Active()
    {

    }

    public virtual void StateUpdate()
    {
        
    }

    
    
}

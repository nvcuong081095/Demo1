using System.Collections.Generic;
using UnityEngine;

namespace Game.StateMachineOne
{
   
public class StateTransitionSO : ScriptableObject
{
    internal  StateTransition GetStateTransition(Dictionary<ScriptableObject, object> instance){
        if( instance.TryGetValue(this, out var existedTransition)){
            return (StateTransition) existedTransition;
        }

        StateTransition newSt = new StateTransition();
        
        return newSt;

    }
} 
}

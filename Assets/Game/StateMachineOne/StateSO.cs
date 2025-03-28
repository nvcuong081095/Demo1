using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.StateMachineOne
{
[CreateAssetMenu(fileName = "New State(StateSO)", menuName = "State Machines/State")]
public class StateSO : ScriptableObject
{
    
    [SerializeField] private StateActionSO[] stateActionsList;
    internal State GetOrCreateState( StateMachine sm){
        
        // if (sm.TryGetValue(this, out var existedState)){
        //     return (State)existedState;
        // }

        // State newState = new State();
        // instance.Add(this, newState);
        // newState._originalSO = this;
        
        // return newState;
        return null;
    }

    private static StateAction[] GetStateActionList(StateActionSO[] actionsSO, Dictionary<ScriptableObject, object> instance){
        StateAction[] result = new StateAction[actionsSO.Count()];
        for (int i = 0; i < actionsSO.Count(); i++){
            result[i] = actionsSO[i].getAction(instance);
        }
        return result;
    }
    
    public void initStateTransitionList(StateSO[] list){
        int length = list.Length;
        StateSO[] result = new StateSO[length - 1 ];
        if (list == null || length == 0) return;
        for ( int i = 0, j = 0; i < length ; i++, j++){
            if (this.GetInstanceID() == list[i].GetInstanceID()) continue;
            result[j] = list[i];
            Debug.Log(result[i].GetInstanceID());
        }
        
    }
} 
}

using UnityEngine;

namespace Game.StateMachineOne
{
   
public abstract class StateTransitionCondition 
{
    private bool isCached = false;
    private bool _cachedStatement = default;
    internal StateTransitionConditionSO _originSO;

    protected StateTransitionConditionSO originSO => _originSO;

    protected abstract bool Statement();
    internal bool GetStatement(){
        if (!isCached){
            isCached = true;
            _cachedStatement = Statement();
        }

        return Statement();
    }

    internal void clearCache(){
        isCached = false;
    }

    public bool IsMet(){
        bool isMet = false;
        bool stateMent = GetStatement();
        return isMet;
    }
} 
}

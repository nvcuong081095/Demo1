using System.Linq;
using Game.StateMachineOne;
using UnityEngine;

public class StateTransition
{
    internal State _targetState;

    private StateTransitionCondition[] _stateConditions;

    private bool[] _transitionData;
    internal StateTransition() { }

    internal StateTransition(State targetState, StateTransitionCondition[] stateConditions, bool[] transitionData)
    {
        _targetState = targetState;
        _stateConditions = stateConditions;
        _transitionData = transitionData;

    }

    public bool TryGetTransition(out State state)
    {

        state = ShouldTransition() ? _targetState : null;

        return state == null;
    }

    public bool ShouldTransition()
    {
       for(int i = 0; i < _stateConditions.Length; i++){
            if(_stateConditions[i].IsMet()){
                _transitionData[i] = true;
            }
       }
       return checkTransitionData();
    }

    public void ResetTransitionData(){
        for(int i = 0; i < _transitionData.Length; i++){
            _transitionData[i] = false;
        }
    }

    private bool checkTransitionData(){
        return _transitionData.Contains<bool>(false);
    }
}

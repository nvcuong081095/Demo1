using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.StateMachineOne
{

    public class State
    {
        //each state has one StateSO
        internal StateSO _originalSO;
        internal StateAction[] _actionList;

        internal State[] _targetTransitionStates;
        
        internal StateTransition _stateTransitionCondition;
        public State(){}
        public State(StateSO originalSO, StateAction[] actionList, State[] targetTransitionStates, StateTransition stateTransitionCondition)
        {
            _originalSO = originalSO;
            _actionList = actionList;
            _targetTransitionStates = targetTransitionStates;
            _stateTransitionCondition = stateTransitionCondition;
        }

        //public bool TryGetTransition(out var state){}
        public void OnStateEnter() {     
        }
        public void OnStateUpdate() {     
        }
        public void OnStateExist() {     
        }

        public bool TryGetTransition(out State transitionToState){
            transitionToState = null;
    
            return false;
        }
        
    }
}

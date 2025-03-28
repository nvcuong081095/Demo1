using System;
using System.Collections.Generic;
using System.Linq;
using Game.StateMachineOne;
using UnityEngine;

[CreateAssetMenu(fileName = "New TableState(TableSO)", menuName = "State Machines/State Table SO")]

public class StateTableSO : ScriptableObject
{

    //[SerializeField] private List<List<ScriptableObject>> transitionTable;
    [SerializeField] private StateTransitionItem[] items = default;




    internal void StateInitialization(StateMachine sm){
        var targetStates = items.GroupBy(item => item.targetState);
        var states = new List<State>();
        var transitions = new List<StateTransition>();
        foreach(var targetState in targetStates){
            if (targetState == null) return;
            transitions.Clear();
            var state = targetState.Key.GetOrCreateState(sm);
            transitions.Add(new StateTransition(state, null,null));
            

        }
    }

    //internal void ProcessTransitionCondition(StateMachine sm, Tra)
    [Serializable]
    public struct StateTransitionItem{
        public StateSO targetState;
        public ConditionToStateTransition conditionToStateTranstion;

    }

    [Serializable]
    public struct ConditionToStateTransition{
        public Result _result;
        public Operator _operator;

        public StateTransitionConditionSO[] _condition;
    }

    public enum Result{
        True,
        False
    }

    public enum Operator{
        AND,
        OR
    }



    
    
}

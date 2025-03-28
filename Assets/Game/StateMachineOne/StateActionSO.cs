using System.Collections.Generic;
using UnityEngine;

namespace Game.StateMachineOne
{
    [CreateAssetMenu(fileName = "New State Action", menuName = "State Machines/State Action ")]
    public abstract class StateActionSO : ScriptableObject
    {
        internal StateAction getAction(Dictionary<ScriptableObject, object> instance)
        {
            if (instance.TryGetValue(this, out var existedStateAction))
            {
                return (StateAction)existedStateAction;
            }

            var newStateAction = CreateStateAction();
            newStateAction.original_SO = this;
            instance.Add(this, newStateAction);
            return newStateAction;



        }

        protected abstract StateAction CreateStateAction();


    }

    public abstract class StateActionSO<T> : StateActionSO where T : StateAction, new(){

        protected override StateAction CreateStateAction() => new T();

    }
}

using Game.StateMachineOne;
using UnityEngine;
using UnityEngine.UI;

namespace Game.SimpleStateMachine
{
    public class SimpleTransition
    {
        internal PlayerController controller;
        internal Button but;

        public void Awake(SimpleStateMachine sm)
        {
            controller = sm.GetComponent<PlayerController>();
        }

        public bool TryToGetTransition(out SimpleState state){
            state = SimpleState.Default;
            if(controller.vectorMovement != Vector3.zero){
                state = SimpleState.Moving;
            }

            if(controller.vectorMovement == Vector3.zero){
                state = SimpleState.Idle;
            }
            return state != SimpleState.Default;
        }
    }
}


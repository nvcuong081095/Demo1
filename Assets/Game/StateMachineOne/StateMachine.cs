using System.Buffers.Text;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.StateMachineOne{
public class StateMachine : MonoBehaviour
{
    [SerializeField] private StateTableSO stateTableSO;
        private State currentState;
        private StateTransition[] stateTransitions;

    }
}
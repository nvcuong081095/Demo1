using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.SimpleStateMachine
{
    public class SimpleStateMachine : MonoBehaviour
    {
        internal SimpleState currentState;
        internal SimpleTransition transition = new SimpleTransition();
        private Dictionary<Type, Component> cache = new Dictionary<Type, Component>();



        private void Awake()
        {
            currentState = SimpleState.Idle;
            transition.Awake(this);
        
        }

        private void Update()
        {
            if(TryToGetTransition(out var state)){
                Transition(state);
            }
            StateUpdate(currentState);

        }


        // public new bool TryGetComponent<T>(out T component) where T : Component
        // {
        //     var type = typeof(T);
        //     if (!cache.TryGetValue(type, out var value))
        //     {
        //         if (base.TryGetComponent<T>(out component))
        //             cache.Add(type, component);
        //         else return component != null;
        //     }
        //     component = (T)value;
        //     return true;
        // }



        // public new T GetComponent<T>() where T : Component
        // {
        //     return TryGetComponent(out T component) ? component : null;
        // }

        private bool TryToGetTransition(out SimpleState state){
            if(transition.TryToGetTransition(out state)){
                Transition(state);
            }
            return state!= SimpleState.Default;

        }
        private void Transition(SimpleState state){
            StateExist(currentState);
            currentState = state;
            StateEnter(state);
        }
        private void StateEnter(SimpleState state){
            switch(state){
                case SimpleState.Idle:
                break;
                case SimpleState.Moving:
                break;
                case SimpleState.Attacking:
                break;
            }
        }

        private void StateUpdate(SimpleState state){
            switch(state){
                case SimpleState.Idle:
                break;
                case SimpleState.Moving:
                break;
                case SimpleState.Attacking:
                break;
            }
        }

        private void StateExist(SimpleState state){
            switch(state){
                case SimpleState.Idle:
                break;
                case SimpleState.Moving:
                break;
                case SimpleState.Attacking:
                break;
            }            
        }
    }
}

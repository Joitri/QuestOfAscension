using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IdleGame.Combat
{
    public abstract class StateMachine : MonoBehaviour
    {
        // Protected so driving class can deligate behaviour down to the current state
        protected State State;

        public void SetState(State state)
        {
            State = state;
            StartCoroutine(State.Start());
        }
    }
}
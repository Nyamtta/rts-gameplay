using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roman.demidow.game
{
    public class MinionIdleState : IState
    {
        public MinionIdleState()
        {

        }

        public void Tick()
        {
            Debug.Log("Idle state");
        }

        public void OnEnter()
        {
        }

        public void OnExit()
        {
        }
    }
}
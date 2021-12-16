using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roman.demidow.game
{
    public class MinionAttackState : IState
    {
        private MinionSettings _minionSettings;

        public MinionAttackState()
        {

        }

        public void Tick()
        {
            Debug.Log("Attack state");
        }

        public void OnEnter()
        {
        }

        public void OnExit()
        {
        }
    }
}
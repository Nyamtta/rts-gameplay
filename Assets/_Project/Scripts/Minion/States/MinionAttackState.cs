using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roman.demidow.game
{
    public class MinionAttackState : IState
    {
        private MinionSettings _minionSettings;
        private IDamageable _attackTarget;
        private Minion _minion;

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
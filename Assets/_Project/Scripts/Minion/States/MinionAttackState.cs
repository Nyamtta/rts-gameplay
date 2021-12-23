using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roman.demidow.game
{
    public class MinionAttackState : IState
    {
        private MinionSettings _minionSettings;
        private MinionAnimations _animator;
        private Minion _minion;
        private IDamageable _attackTarget;
        private MinionAnimationEvent _attackAction;

        public MinionAttackState(MinionSettings minionSettings, Minion minion, MinionAnimations minionAnimations, MinionAnimationEvent attackAction)
        {
            _minionSettings = minionSettings;
            _minion = minion;
            _animator = minionAnimations;
            _attackAction = attackAction;
        }

        public void Tick()
        {
            Debug.Log("Attack state");
        }

        public void OnEnter()
        {
            _attackTarget = _minion.GetCurrentEnemy();
            _animator.SetAttack(true);
            _attackAction.onSetDamage += SetDamage;
        }

        public void OnExit()
        {
            _animator.SetAttack(false);
            _attackAction.onSetDamage -= SetDamage;
        }

        public void SetDamage()
        {
            Debug.Log("0.2");
            _attackTarget.TakeDamage(DamageType.Hit, _minionSettings.AttackDamage);
        }
    }
}
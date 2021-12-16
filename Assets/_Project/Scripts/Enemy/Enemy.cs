using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roman.demidow.game
{
    public abstract class Enemy : MonoBehaviour, IDamageable
    {
        [SerializeField] private EnemySettings _enemySettings;

        private float _hitPoint;

        private void Init()
        {
            _hitPoint = _enemySettings.HitPoint;
        }

        public virtual void TakeDamage(DamageType damageType, float damage)
        {
            _hitPoint -= damage;
        }
    }
}
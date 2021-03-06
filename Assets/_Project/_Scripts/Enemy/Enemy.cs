using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roman.demidow.game
{
    public abstract class Enemy : MonoBehaviour, IDamageable
    {
        [SerializeField] private EnemySettings _enemySettings;
        [SerializeField] private CharacterType _characterType;

        private float _hitPoint;

        private void Init()
        {
            _hitPoint = _enemySettings.HitPoint;
        }

        public virtual void TakeDamage(DamageType damageType, float damage)
        {
            Debug.Log(_hitPoint);
            _hitPoint -= damage;

            Debug.Log("hit");

            if (_hitPoint <= 0)
                Debug.Log("Dye");
        }

        public CharacterType GetCharacterType()
        {
            return _characterType;
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }
    }
}
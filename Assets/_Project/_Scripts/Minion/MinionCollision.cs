using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roman.demidow.game
{
    public class MinionCollision : MonoBehaviour
    {
        public delegate void CollisionData(IDamageable damageableObject, bool isEnterTrigger);
        
        public event CollisionData onSightZone;
        public event CollisionData onAttacZone;


        private List<IDamageable> _inSightZone;
        private List<IDamageable> _inAttacZone;

        public void Init()
        {
            _inSightZone = new List<IDamageable>();
            _inAttacZone = new List<IDamageable>();
        }

        private void OnTriggerEnter(Collider other)
        {
            CheckIsObjectEnemy(other, true);
        }

        private void OnTriggerExit(Collider other)
        {
            CheckIsObjectEnemy(other, false);
        }

        private void CheckIsObjectEnemy(Collider collider, bool isEnter)
        {
            if (collider.TryGetComponent<IDamageable>(out IDamageable damageable) == true)
            {
                if (damageable.GetCharacterType() != CharacterType.Enemy)
                    return;

                if(isEnter == true)
                {
                    AddEnemy(damageable);
                }
                else
                {
                    RemoveEnemy(damageable);
                }
            }
        }

        private void AddEnemy(IDamageable damageable)
        {
            bool enemyOnZone = true;

            if (_inSightZone.Contains(damageable) == true)
            {
                _inAttacZone.Add(damageable);
                onAttacZone.Invoke(damageable, enemyOnZone);
            }
            else
            {
                _inSightZone.Add(damageable);
                onSightZone?.Invoke(damageable, enemyOnZone);
            }
        }

        private void RemoveEnemy(IDamageable damageable)
        {
            bool enemyOnZone = false;

            if (_inAttacZone.Contains(damageable) == true)
            {
                _inAttacZone.Remove(damageable);
                onAttacZone.Invoke(damageable, enemyOnZone);
            }
            else if(_inSightZone.Contains(damageable) == true)
            {
                _inSightZone.Remove(damageable);
                onSightZone?.Invoke(damageable, enemyOnZone);
            }
        }
    }
}
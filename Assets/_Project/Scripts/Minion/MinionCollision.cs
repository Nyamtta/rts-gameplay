using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roman.demidow.game
{
    public class MinionCollision : MonoBehaviour
    {
        public event Action<IDamageable , bool> onEnemyClose;
        public event Action<IDamageable, bool> onTouchEnemy;

        public void Init()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            OnTrigger(other, true);
        }

        private void OnTriggerExit(Collider other)
        {
            OnTrigger(other, false);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log(collision.transform.name);
            OnCollision(collision, true);
        }

        private void OnCollisionExit(Collision collision)
        {
            OnCollision(collision, false);
        }

        private void OnTrigger(Collider collider, bool isEnter)
        {
            if (collider.TryGetComponent<IDamageable>(out IDamageable damageable) == true)
            {
                switch (damageable.GetCharacterType())
                {
                    case CharacterType.Ally:
                        break;
                    case CharacterType.Enemy:
                        onEnemyClose?.Invoke(damageable, isEnter);
                        break;
                    default:
                        break;
                }
            }
        }

        private void OnCollision(Collision collision, bool isEnter)
        {
            if (collision.transform.TryGetComponent<IDamageable>(out IDamageable damageable) == true)
            {
                switch (damageable.GetCharacterType())
                {
                    case CharacterType.Ally:
                        break;
                    case CharacterType.Enemy:
                        onTouchEnemy?.Invoke(damageable, isEnter);
                        break;
                    default:
                        break;
                }
            }
        }


    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roman.demidow.game
{

    public interface IDamageable
    {
        public void TakeDamage(DamageType damageType, float damage);
        
        public CharacterType GetCharacterType();

        public Vector3 GetPosition();

    }

    public enum DamageType
    {
        Hit
    }

    public enum CharacterType
    { 
        Ally,
        Enemy
    }

}


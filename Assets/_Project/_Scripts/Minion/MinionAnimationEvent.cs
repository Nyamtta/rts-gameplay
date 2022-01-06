using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roman.demidow.game
{
    public class MinionAnimationEvent : MonoBehaviour
    {
        private GameObject _weaponHolsterGO;
        private GameObject _weaponInHandHolderGO;

        public event Action onSetDamage;

        internal void Init(GameObject weaponHolster, GameObject weaponInHandHolder)
        {
            _weaponHolsterGO = weaponHolster;
            _weaponInHandHolderGO = weaponInHandHolder;
        }

        public void HideWeapon()
        {
            _weaponHolsterGO.SetActive(true);
            _weaponInHandHolderGO.SetActive(false);
        }

        public void TakeWeapon()
        {
            _weaponHolsterGO.SetActive(false);
            _weaponInHandHolderGO.SetActive(true);
        }

        public void SetDamage()
        {
            onSetDamage?.Invoke();
        }

    }
}
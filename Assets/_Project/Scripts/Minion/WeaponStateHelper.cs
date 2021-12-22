using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStateHelper : MonoBehaviour
{
    private GameObject _weaponHolsterGO;
    private GameObject _weaponInHandHolderGO;
    
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

}

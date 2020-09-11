using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private Transform _plasmaRifle;
    private Transform _autoRifle;
    private Transform _gun;
    private Transform _shootGun;
    void Start()
    {
        WeaponManagerInitialize();
    }

    void Update()
    {

    }
    void WeaponManagerInitialize()
    {
        _plasmaRifle = transform.Find("PlasmaRifle");
        if(_plasmaRifle == null)
        {
            Debug.Log("WeaponManager_script Error! _plasmaRifle is NULL!");
        }

        _autoRifle = transform.Find("AutoRifle");
        if (_autoRifle == null)
        {
            Debug.Log("WeaponManager_script Error! _autoRifle is NULL!");
        }

        _gun = transform.Find("Gun");
        if (_gun == null)
        {
            Debug.Log("WeaponManager_script Error! _gun is NULL!");
        }

        _shootGun = transform.Find("ShootGun");
        if (_shootGun == null)
        {
            Debug.Log("WeaponManager_script Error! _shootGun is NULL!");
        }

        TakeAPlasmaRifle();
    }
    public void TakeAGun()
    {
        //_gun.gameObject.SetActive(true);
        //_autoRifle.gameObject.SetActive(false);
        _plasmaRifle.gameObject.SetActive(false);
        //_shootGun.gameObject.SetActive(false);
    }
    public void TakeAPlasmaRifle()
    {
        //_gun.gameObject.SetActive(false);
        //_autoRifle.gameObject.SetActive(false);
        _plasmaRifle.gameObject.SetActive(true);
        //_shootGun.gameObject.SetActive(false);
    }
    public void TakeAShootGun()
    {
        //_gun.gameObject.SetActive(false);
        //_autoRifle.gameObject.SetActive(false);
        _plasmaRifle.gameObject.SetActive(false);
        //_shootGun.gameObject.SetActive(true);
    }
    public void TakeAAutoRifle()
    {
        //_gun.gameObject.SetActive(false);
        //_autoRifle.gameObject.SetActive(true);
        _plasmaRifle.gameObject.SetActive(false);
        //_shootGun.gameObject.SetActive(false);
    }
}

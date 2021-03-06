using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100;
    [SerializeField] float damage = 25;
    [SerializeField] ParticleSystem muzzleFlash;

    public float GetDamage()
    {
        return damage;  
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRaycast();

    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play(); 
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            Debug.Log("I hit this thing: " + hit.transform.name);
            if (hit.transform.name.Equals("Enemy"))
            {
                //TODO: Add hit effect
                hit.transform.GetComponent<EnemyHealth>().TakeDamage(this);
                //target.TakeDamage(this);
            }
        }
        else
        {
            return;
        }
    }
}

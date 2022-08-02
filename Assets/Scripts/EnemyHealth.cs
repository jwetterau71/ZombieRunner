using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitpoints = 100f;

    public void TakeDamage(Weapon weapon)
    {
        this.hitpoints -= weapon.GetDamage();
        Debug.Log("Ouch!!  I only have " + hitpoints + " left!");
        if(this.hitpoints <= 0)
        {
            Debug.Log("Alas - I am slain!");
            Destroy(gameObject);
        }
    }
}

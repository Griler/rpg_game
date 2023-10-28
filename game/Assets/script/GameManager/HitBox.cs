using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damage = this.gameObject.GetComponentInParent<IDamageable>();
        IDamageable takedamage = other.GetComponent<IDamageable>();
        if (takedamage != null)
            takedamage.Damage(damage.getDamage());
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] float damage;

    public float Damage { get { return damage; } }

    public GameObject DamageSource { get; set; }
}

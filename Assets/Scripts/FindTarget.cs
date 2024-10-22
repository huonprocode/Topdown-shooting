using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTarget : MonoBehaviour
{
    private Weapon weapon;
    private void Awake()
    {
        weapon = GetComponent<Weapon>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<EnemyController>(out EnemyController enemy))
        {
            weapon.SetTarget(enemy);

        }
    }
}
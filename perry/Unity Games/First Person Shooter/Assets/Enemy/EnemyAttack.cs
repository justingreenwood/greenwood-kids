using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 10f;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    void AttackHitEvent()
    {
        if(target == null) return;
        target.TakeDamage(damage);
        target.GetComponent<DisplayDamage>().PaintDamage();
    }

}

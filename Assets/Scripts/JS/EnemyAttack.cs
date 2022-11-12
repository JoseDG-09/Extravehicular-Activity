using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public BarLife logicBarLife;
    private float damage = 5.0f;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            logicBarLife.actualLife -= damage;
        }
    }

    
}

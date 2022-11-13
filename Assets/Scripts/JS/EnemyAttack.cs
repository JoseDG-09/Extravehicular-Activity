using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyAttack : MonoBehaviour
{
    public BarLife logicBarLife;
    private float damage = 5.0f;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            logicBarLife.actualLife -= damage;
            Debug.Log("Ataque");
        }
    }

    
}

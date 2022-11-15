using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour
{
    public float damage = 5;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player") && collision.GetComponent<BarLifePlayer>())
        {
            collision.GetComponent<BarLifePlayer>().ReciveDamage(damage);
            Debug.Log("Ataque");
        }
    }
}

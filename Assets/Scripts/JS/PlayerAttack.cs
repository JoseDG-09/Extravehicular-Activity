using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float damage = 5;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Enemy") && collision.GetComponent<BarLifeEnemy>())
        {
            Destroy(this.gameObject);
            collision.GetComponent<BarLifeEnemy>().ReciveDamage(damage);
            Debug.Log("AtaquePlayer");
        }
    }
}

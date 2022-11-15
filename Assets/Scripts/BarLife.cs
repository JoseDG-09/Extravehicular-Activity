using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarLife : MonoBehaviour
{
    public float lifeMax;
    public float actualLife;
    public Image imageBarLife;
    public EnemyController enemyController;
    // Start is called before the first frame update
    void Start()
    {
        actualLife = lifeMax;
        enemyController.attack = true;
    }

    // Update is called once per frame
    void Update()
    {
        ConfirmLife();
        if(actualLife <= 0)
        {
            gameObject.SetActive(false);
            enemyController.attack = false;
        }
    }

    void ReciveDamage(float damage)
    {
        actualLife -= damage;
    }

    public void ConfirmLife()
    {
        imageBarLife.fillAmount = actualLife / lifeMax;
    }
}

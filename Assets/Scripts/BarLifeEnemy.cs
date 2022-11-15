using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarLifeEnemy : MonoBehaviour
{
    public int lifeMax;
    public float actualLife;
    public Image imageBarLife;
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        actualLife = lifeMax;
    }

    // Update is called once per frame
    void Update()
    {
        ConfirmLife();
        if (actualLife <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void ReciveDamage(float damage)
    {
        actualLife -= damage;
    }

    public void ConfirmLife()
    {
        imageBarLife.fillAmount = actualLife / lifeMax;
    }
}

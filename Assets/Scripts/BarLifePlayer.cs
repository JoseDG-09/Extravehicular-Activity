using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarLifePlayer : MonoBehaviour
{
    public int lifeMax;
    private float actualLife;
    public Image imageBarLife;
    public EnemyController enemyController;
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
            Dead();
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

    public void Dead()
    {
        SceneManager.LoadScene(2);
        Cursor.lockState = (Input.GetKey(KeyCode.Escape) ? CursorLockMode.None : CursorLockMode.None);
    }
}

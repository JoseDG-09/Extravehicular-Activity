using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statistics : MonoBehaviour
{
    public float enemyDamage = 5f;

    [Header("Aumentar al coger")]
    public int waterValue = 10;
    public int bulletValue = 10;
    public int lifeValue = 10;

    [Header("Disminuir con el tiempo")]
    public int waterDecrease = 5;
    public int lifeDecrease = 5;

    [Header("UI Water")]
    public float startinWater;
    public Slider slider;
    public Image fillImage;
    public Color fullWaterColor = Color.blue;
    public Color zeroWaterColor = Color.red;

    [Header("UI Life")]
    public float startinLife;
    public Slider sliderLife;
    public Image fillImageLife;
    public Color fullLifeColor = Color.green;
    public Color zeroLifeColor = Color.red;

    [Header("UI Bullet")]
    public Text textBullet;

    int bullet = 0;
    //int water = 100;
    private float currentWater;
    float currenLife;

    private void Start()
    {
        SetBullet();
        currentWater = startinWater;
        currenLife = startinLife;
        SetWaterUI();
        SetLifeUI();
        InvokeRepeating("StatsDecrease", 2f, 2f);

    }

    void StatsDecrease()
    {
        if (currentWater <= 0)
        {
            currenLife -= lifeDecrease;
            SetLifeUI();
            if (currenLife <= 0)
            {
                Debug.Log("Life is: " + currenLife);
                Debug.Log("Game Over");
            }
        }

        if (currentWater > 0)
        {
            currentWater -= waterDecrease;
            SetWaterUI();
        }
        
        Debug.Log("Water is: " + currentWater);
        Debug.Log("Life is: " + currenLife);
    }

    private void SetWaterUI()
    {
        slider.value = currentWater;
        fillImage.color = Color.Lerp(zeroWaterColor, fullWaterColor, currentWater / startinWater);
    }

    private void SetLifeUI()
    {
        sliderLife.value = currenLife;
        fillImageLife.color = Color.Lerp(zeroLifeColor, fullLifeColor, currenLife / startinLife);
    }

    private void SetBullet()
    {
        textBullet.text = "Balas: " + bullet.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water") && currentWater < 100) { 
            Debug.Log("More water");
            currentWater += waterValue;
            SetWaterUI();
            Destroy(other.gameObject);
        }        

        if (other.CompareTag("Life") && currenLife < 100)
        {
            Debug.Log("More Life");
            currenLife += lifeValue;
            SetLifeUI();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Less Life");
            currenLife -= enemyDamage;
            SetLifeUI();
            //Destroy(other.gameObject);
        }

        if (other.CompareTag("Bullet"))
        {
            Debug.Log("More Bullets");
            bullet += bulletValue;
            SetBullet();
            Destroy(other.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statistics : MonoBehaviour
{
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

    int bullet = 0;
    //int water = 100;
    private float currentWater;
    int life = 70;

    private void Start()
    {
        currentWater = startinWater;
        SetWaterUI();
        InvokeRepeating("StatsDecrease", 2f, 2f);

    }

    void StatsDecrease()
    {
        if (currentWater <= 0)
        {
            life -= lifeDecrease;
            if(life <= 0)
            {
                Debug.Log("Life is: " + life);
                Debug.Log("Game Over");
            }
        }

        if (currentWater > 0)
        {
            currentWater -= waterDecrease;
            SetWaterUI();
        }
        
        Debug.Log("Water is: " + currentWater);
        Debug.Log("Life is: " + life);
    }

    private void SetWaterUI()
    {
        slider.value = currentWater;
        fillImage.color = Color.Lerp(zeroWaterColor, fullWaterColor, currentWater / startinWater);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water") && currentWater < 100) { 
            Debug.Log("More water");
            currentWater += waterValue;
            SetWaterUI();
            Destroy(other.gameObject);
        }        

        if (other.CompareTag("Life") && life < 100)
        {
            Debug.Log("More Life");
            life += lifeValue;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Bullet"))
        {
            Debug.Log("More Bullets");
            bullet += bulletValue;
            Destroy(other.gameObject);
        }
    }
}

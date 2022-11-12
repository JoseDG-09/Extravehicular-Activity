using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWater : MonoBehaviour
{
    public float startinWater;
    public Slider slider;
    public Image fillImage;
    public Color fullWaterColor = Color.blue;
    public Color zeroWaterColor = Color.red;

    private float currentWater;
    private bool dead;

    private void Start()
    {
        currentWater = startinWater;
        dead = false;
        SetWaterUI();
    }

    public void TakeDamage(float amount)
    {
        currentWater -= amount;
        SetWaterUI();
        if(currentWater <= 0f)
        {
            Debug.Log("Sin Water");
            dead = true;
        }
    }

    private void SetWaterUI()
    {
        slider.value = currentWater;
        fillImage.color = Color.Lerp(zeroWaterColor, fullWaterColor, currentWater / startinWater);
    }
}

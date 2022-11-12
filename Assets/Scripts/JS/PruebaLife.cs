using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaLife : MonoBehaviour
{
    public BarLife logicBarLife;
    public float damage = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            logicBarLife.actualLife -= damage;
        }
    }
}

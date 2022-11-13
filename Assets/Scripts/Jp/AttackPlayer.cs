using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public Rigidbody laser;
    public Transform puntoDeDisparo;
    //public GameObject efecto;
    public float velocidad;

    private void Start()
    {
        puntoDeDisparo = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Launch a projectile from the play 


            Rigidbody disparo = Instantiate(laser, puntoDeDisparo.position, Quaternion.Euler(-90,0,0)) as Rigidbody;
            disparo.velocity = puntoDeDisparo.forward * velocidad;
            //efecto.transform.position = puntoDeDisparo.position;
            //Instantiate(efecto);
        }
    }
}

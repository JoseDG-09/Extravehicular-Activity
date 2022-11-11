using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayer : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    Rigidbody rbPlayer;
    float movZ;
    float turnX;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movZ = Input.GetAxis("Vertical");
        turnX = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
        Animating(movZ, turnX);
        //rbPlayer.MovePosition(rbPlayer.position + speed * Time.fixedDeltaTime * transform.forward * movZ);
        //rbPlayer.MoveRotation(rbPlayer.rotation * Quaternion.Euler(0, turnX * turnSpeed * Time.fixedDeltaTime, 0 ));
    }

    private void Move()
    {
        Vector3 movement = transform.forward * movZ * speed * Time.fixedDeltaTime;
        rbPlayer.MovePosition(rbPlayer.position + movement);
    }

    private void Turn()
    {
        float turn = turnX * turnSpeed * Time.fixedDeltaTime;
        rbPlayer.MoveRotation(rbPlayer.rotation * Quaternion.Euler(0, turn, 0));
    }

    void Animating(float z, float x)
    {
        anim.SetFloat("SpeedZ_f", z);
        anim.SetFloat("SpeedX_f", x);
    }

}

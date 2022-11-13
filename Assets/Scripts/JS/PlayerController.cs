using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    //Variables player movement and animation
    public float speedMove = 5.0f;
    public float speedRotation = 200.0f;
    private Animator animator;
    public float x, y;
    private Transform tr;
    public bool aiming;

    //Variables camera
    public Transform cameraShoulder;
    public Transform cameraHolder;
    private Transform cam;
    private float rotateY = 0;
    public float rotationSpeed = 200;
    public float minAngle = -45;
    public float maxAngle = 45;
    public float cameraSpeed = 200;
    public Transform aimingCamera;

    //Variables weapon
    public bool shooting;
    public WeaponController weapon;

    private void Start()
    {
        tr = this.transform;
        cam = Camera.main.transform;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

        CameraController();

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * x * speedMove * Time.deltaTime);

        transform.Translate(0, 0, y * Time.deltaTime * speedMove);

        shooting = Input.GetKeyDown(KeyCode.Mouse0);
        aiming = Input.GetKey(KeyCode.Mouse1);

        GunController();

        animator.SetFloat("speedX", x);
        animator.SetFloat("speedY", y);
    }

    private void CameraController()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float deltaT = Time.deltaTime;

        rotateY += mouseY * rotationSpeed * deltaT;
        float rotateX = mouseX * rotationSpeed * deltaT;
        tr.Rotate(0, rotateX, 0);
        rotateY = Mathf.Clamp(rotateY, minAngle, maxAngle);
        Quaternion localRotation = Quaternion.Euler(-rotateY, 0, 0);
        cameraShoulder.localRotation = localRotation;

        if(aiming)
        {
            cam.position = Vector3.Lerp(cam.position, aimingCamera.position, cameraSpeed * deltaT);
            cam.rotation = Quaternion.Lerp(cam.rotation, aimingCamera.rotation, cameraSpeed * deltaT);
        }
        else
        {
            cam.position = Vector3.Lerp(cam.position, cameraHolder.position, cameraSpeed * deltaT);
            cam.rotation = Quaternion.Lerp(cam.rotation, cameraHolder.rotation, cameraSpeed * deltaT);
        }
    }

    private void GunController()
    {
        if(weapon != null)
        {
            weapon.DrawSight(cam);
            if(shooting)
            {
                weapon.Shoot();
            }
        }
        Cursor.lockState = (Input.GetKey(KeyCode.Escape) ? CursorLockMode.None : CursorLockMode.Locked);
    }

}

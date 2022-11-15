using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Transform shootPoint;
    public Transform bulletPrefab;

    //Sight
    private Transform sight;

    private void Start()
    {
        sight = GetComponentInChildren<Canvas>().transform;
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
    }

    public void DrawSight(Transform camera)
    {
        RaycastHit hit;
        if(Physics.Raycast(camera.position, camera.forward, out hit))
        {
            shootPoint.LookAt(hit.point);
        }
        else
        {
            Vector3 end = camera.position + camera.forward;
            shootPoint.LookAt(end);
        }
    }

}

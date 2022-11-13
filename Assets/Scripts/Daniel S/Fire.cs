using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour

{
    public GameObject projectilePrefab;
    public Transform bulletSpawnPoint;
    
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(projectilePrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * speed;
        }
        
    }
}

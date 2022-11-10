using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5;
    public float speedRotate = 200;
    private Animator animator;
    public float x, y;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        transform.Rotate(0, x * Time.deltaTime * speedRotate, 0);
        transform.Translate(0, 0, y * Time.deltaTime * speed);

        animator.SetFloat("speedX", x);
        animator.SetFloat("speedY", y);
    }
}

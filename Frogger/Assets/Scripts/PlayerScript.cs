using System.Collections;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int speed;

    private Rigidbody2D rb;

    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetTrigger("walkTrigger");
            transform.rotation = Quaternion.Euler(0, 0, -90);
            transform.position += new Vector3(speed, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetTrigger("walkTrigger");
            transform.rotation = Quaternion.Euler(0, 0, 90);
            transform.position -= new Vector3(speed, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetTrigger("walkTrigger");
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position += new Vector3(0, speed, 0);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetTrigger("walkTrigger");
            transform.rotation = Quaternion.Euler(0, 0, 180);
            transform.position -= new Vector3(0, speed, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D playerCollision)
    {
        if (playerCollision.gameObject.CompareTag("Enemy"))
        {
            animator.SetTrigger("deathTrigger");
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }
}

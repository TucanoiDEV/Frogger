using System.Collections;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int speed;

    private Rigidbody2D rb;

    private Animator animator;

    [SerializeField] private bool isSafe;
    [SerializeField] private bool isDead = false;

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
        if(speed == 1)
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
    }

    private void OnCollisionEnter2D(Collision2D playerCollision)
    {
        if (playerCollision.gameObject.CompareTag("Log"))
        {
            isSafe = true;
        }

        if (playerCollision.gameObject.CompareTag("Enemy") && isSafe == false)
        {
            animator.SetTrigger("deathTrigger");
        }
    }
    private void OnCollisionExit2D(Collision2D playerCollision)
    {
       isSafe = false;
    }
    private void OnTriggerStay2D(Collider2D playerCollision)
    {
        if(playerCollision.CompareTag("Water"))
        {
            if(isSafe == false && isDead == false)
            {
                isDead = true;
                animator.SetTrigger("deathTrigger");
            }
        }
    }

    void Stop()
    {
        speed = 0;
    }

    void Death()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public int speed;

    private Rigidbody2D rb;

    public AudioSource audioMovement;
    public AudioSource audioDeath;

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
                audioMovement.Play();
                animator.SetTrigger("walkTrigger");
                transform.rotation = Quaternion.Euler(0, 0, -90);
                transform.position += new Vector3(speed, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                audioMovement.Play();
                animator.SetTrigger("walkTrigger");
                transform.rotation = Quaternion.Euler(0, 0, 90);
                transform.position -= new Vector3(speed, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                audioMovement.Play();
                animator.SetTrigger("walkTrigger");
                transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.position += new Vector3(0, speed, 0);
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                audioMovement.Play();
                animator.SetTrigger("walkTrigger");
                transform.rotation = Quaternion.Euler(0, 0, 180);
                transform.position -= new Vector3(0, speed, 0);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D playerCollision)
    {
        if(playerCollision.gameObject.CompareTag("Checkpoint"))
        {
            SceneManager.LoadScene("End");
        }
        if (playerCollision.gameObject.CompareTag("Log"))
        {
            isSafe = true;
            transform.parent = playerCollision.transform;
        }

        if (playerCollision.gameObject.CompareTag("Enemy") && isSafe == false)
        {
            audioDeath.Play();
            animator.SetTrigger("deathTrigger");
        }
    }
    private void OnCollisionExit2D(Collision2D playerCollision)
    {
       isSafe = false;
       transform.parent = null;
    }
    private void OnTriggerStay2D(Collider2D playerCollision)
    {
        if(playerCollision.CompareTag("Water"))
        {
            if(isSafe == false && isDead == false)
            {
                isDead = true;
                audioDeath.Play();
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

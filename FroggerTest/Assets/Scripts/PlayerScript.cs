using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public int speed;

    public Animator animator;

    [SerializeField] private bool isSafe;
    [SerializeField] private bool isDead = false;

    void Start()
    {
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
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                animator.SetTrigger("walkTrigger");
                transform.position += Vector3.up * speed;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                animator.SetTrigger("walkTrigger");
                transform.position += Vector3.down * speed;
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                animator.SetTrigger("walkTrigger");
                transform.position += Vector3.left * speed;
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                animator.SetTrigger("walkTrigger");
                transform.position += Vector3.right * speed;
                transform.rotation = Quaternion.Euler(0, 0, -90);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D playerCollision)
    {
        if (playerCollision.gameObject.CompareTag("Log"))
        {
            isSafe = true;
            transform.parent = playerCollision.transform;
        }
        if (playerCollision.gameObject.CompareTag("Enemy") && isDead == false)
        {
            isDead = true;
            animator.SetTrigger("deathTrigger");
        }
        if(playerCollision.gameObject.CompareTag("Checkpoint"))
        {
            Respawn();
        }
    }
    private void OnCollisionExit2D(Collision2D playerCollision)
    {
        isSafe = false;
        transform.parent = null;
    }
    private void OnTriggerStay2D(Collider2D playerCollision)
    {
        if (playerCollision.CompareTag("Water"))
        {
            if (isSafe == false && isDead == false)
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

    void Respawn()
    {
        transform.position = new Vector2(0, -4.5f);
        speed = 1;
        isDead = false;
    }
}
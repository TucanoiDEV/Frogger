using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int speed;

    public Animator animator; 

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
    private void OnCollisionEnter2D(Collision2D playerCollision)
    {
        if (playerCollision.gameObject.tag == "Car")
        {
            Destroy(gameObject);
        }
    }
}
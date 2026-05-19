using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int speed;
    private Rigidbody2D playerRb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
            transform.position += new Vector3(speed, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            transform.position -= new Vector3(speed, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position += new Vector3(0, speed, 0);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
            transform.position -= new Vector3(0, speed, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D playerCollision)
    {
        if (playerCollision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}

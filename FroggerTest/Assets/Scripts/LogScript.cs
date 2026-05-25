using UnityEngine;

public class LogScript : MonoBehaviour
{
    public float speed;
    public bool isMovingRight;

    // Update is called once per frame
    void Update()
    {
        Movement();
        Respawn();
    }

    void Movement()
    {
        if (isMovingRight == true)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }

    void Respawn()
    {
        if (transform.position.x > 25 && isMovingRight == true)
        {
            transform.position = new Vector2(-25, transform.position.y);
        }
        if (transform.position.x < -25 && isMovingRight == false)
        {
            transform.position = new Vector2(25, transform.position.y);
        }
    }
}

using UnityEngine;

public class CarScript : MonoBehaviour
{
    public float speed;
    public bool isMovingRight;

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if(isMovingRight == true)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }


}

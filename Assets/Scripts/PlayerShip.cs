using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    float speed = 0.06f; // how far the paddle moves per frame

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }

        if (Input.GetKey(KeyCode.Space))
        {

        }
    }

    void MoveLeft()
    {
        transform.position = new Vector2(transform.position.x - speed, transform.position.y);
    }

    void MoveRight()
    {
        transform.position = new Vector2(transform.position.x + speed, transform.position.y);
    }

    /// <summary>
    /// Shoots from the ship's position.
    /// </summary>
    void Shoot()
    {

    }
}

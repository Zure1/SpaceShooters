using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    float speed = 0.06f; // how far the paddle moves per frame
    float shipHeight;    
    public GameObject Laser1;

    Vector3 movePosition = new Vector3(10f, 10f, 10f);

    GameObject shot;

    // Start is called before the first frame update
    void Start()
    {
        shipHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        //if (shot != null)
        //{
        //    Vector3 newPos = Vector3.MoveTowards(shot.transform.position, movePosition, laserSpeed);
        //    shot.transform.position = newPos;
        //}

        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
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
        shot = Instantiate(Laser1, new Vector3(transform.position.x, transform.position.y + shipHeight + Laser1.transform.GetComponent<SpriteRenderer>().bounds.extents.y), Quaternion.identity);
    }
}

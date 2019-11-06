using UnityEngine;

public class PlayerShip : Ship
{
    float shipHeight;    
    public GameObject Laser1;

    // Start is called before the first frame update
    void Start()
    {
        shipHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    /// <summary>
    /// Shoots from the ship's position.
    /// </summary>
    public void Shoot()
    {
        var laser = Instantiate(Laser1, new Vector3(transform.position.x, transform.position.y + shipHeight + Laser1.transform.GetComponent<SpriteRenderer>().bounds.extents.y + 0.1f), Quaternion.identity);
        var laserScript = laser.GetComponent<LaserScript>();
        if (laserScript != null)
        {
            laserScript.SetLaserDirection(ShootingDirection);
        }
    }
}

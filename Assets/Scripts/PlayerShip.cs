using UnityEngine;

public class PlayerShip : Ship
{
    float shipHeight;    
    public GameObject Laser1;
    public float ShootingRate;
    float shootCooldown;

    // Start is called before the first frame update
    void Start()
    {
        shipHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }

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
            Shoot();
        }
    }

    /// <summary>
    /// Shoots from the ship's position.
    /// </summary>
    public void Shoot()
    {
        if (shootCooldown < Time.deltaTime)
        {    
            var laser = Instantiate(Laser1, new Vector3(transform.position.x, transform.position.y + shipHeight + Laser1.transform.GetComponent<SpriteRenderer>().bounds.extents.y + 0.1f), Quaternion.identity);
            var laserScript = laser.GetComponent<LaserScript>();
            if (laserScript != null)
            {
                laserScript.SetLaserDirection(ShootingDirection);
            }
            shootCooldown = ShootingRate;
        }
    }
}

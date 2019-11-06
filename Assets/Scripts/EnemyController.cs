using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Ship
{
    public bool IsPartOfGroup;
    public bool IsMovingLeft = true, IsMovingDown;
    public Transform Target;
    public GameObject Laser1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsPartOfGroup)
        {
            if (IsMovingDown)
            {

            }
            else if (IsMovingLeft)
            {
                MoveLeft();
            }
            else
            {
                MoveRight();
            }
        }
    }

    /// <summary>
    /// Shoots from the ship's position.
    /// </summary>
    public void Shoot()
    {
        var laser = Instantiate(Laser1, new Vector3(transform.position.x, transform.position.y - transform.GetComponent<SpriteRenderer>().bounds.extents.y - Laser1.transform.GetComponent<SpriteRenderer>().bounds.extents.y - 0.1f), Quaternion.identity);
        var laserScript = laser.GetComponent<LaserScript>();
        if (laserScript != null)
        {
            laserScript.SetLaserDirection(ShootingDirection);
            laserScript.IsHostile = true;
        }
    }
}

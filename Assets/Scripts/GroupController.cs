using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupController : MonoBehaviour
{
    public float Speed;
    public bool IsMovingLeft = true, IsMovingDown;
    public Vector3 Target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsMovingDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target, Speed);
            if (transform.position == Target)
            {
                IsMovingDown = false;
                IsMovingLeft = !IsMovingLeft;
            }
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

    void MoveLeft()
    {
        transform.position = new Vector2(transform.position.x - Speed, transform.position.y);
    }

    void MoveRight()
    {
        transform.position = new Vector2(transform.position.x + Speed, transform.position.y);
    }
}

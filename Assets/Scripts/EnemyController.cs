using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Ship
{
    public bool IsPartOfGroup;
    public bool IsMovingLeft = true, IsMovingDown;
    public Transform Target;

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
}

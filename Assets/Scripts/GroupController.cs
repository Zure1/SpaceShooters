using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupController : MonoBehaviour
{
    public float Speed;
    public bool IsMovingLeft = true, IsMovingDown;
    public Vector3 Target;
    public List<GameObject> ListChildren = new List<GameObject>();

    float timer = 0f;
    float waitingTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            ListChildren.Add(transform.GetChild(i).gameObject);
        }
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

        // TODO: Random Shoot for one Gameobject in Group
        timer += Time.deltaTime;
        if (timer > waitingTime)
        {
            //Action
            timer = 0;

            if (ListChildren?.Count > 0)
            {
                var randomIndex = Random.Range(0, ListChildren.Count);
                var enemyController = ListChildren[randomIndex].GetComponent<EnemyController>();
                if (enemyController != null)
                {
                    enemyController.Shoot();
                }
            }
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

    /// <summary>
    /// Removes one child from the ChildrenList of this GroupController.
    /// </summary>
    /// <param name="obj">The GameObject that will be removed from the ChildrenList.</param>
    public void RemoveChildFromChildrenList(GameObject obj)
    {
        ListChildren.Remove(obj);
        if (ListChildren?.Count == 0)
        {
            Destroy(gameObject, 1);
        }
    }
}

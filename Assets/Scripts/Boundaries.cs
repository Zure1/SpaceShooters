using UnityEngine;

public class Boundaries : MonoBehaviour
{
    public Camera MainCamera;
    Vector2 screenBounds;
    float objectWidth, objectHeight;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        var spriteRenderer = transform.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            objectWidth = spriteRenderer.bounds.extents.x; //extents = size of width / 2
            objectHeight = spriteRenderer.bounds.extents.y; //extents = size of height / 2
        }
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);

        if (transform.position != viewPos)
        {
            if (gameObject.tag == "HostileShip")
            {
                var groupController = gameObject.transform.parent.gameObject.GetComponent<GroupController>();
                //var groupController = gameObject.GetComponent<GroupController>();
                if (groupController != null)
                {
                    groupController.Target = new Vector3(groupController.transform.position.x, groupController.transform.position.y - 1);
                    groupController.IsMovingDown = true;
                }
            }
            transform.position = viewPos;
        }
    }
}

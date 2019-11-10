using UnityEngine;

public class KillPlayerShipOnTrigger : MonoBehaviour
{
    public PlayerShip CurrentPlayerShip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HostileShip"))
        {
            var healthScript = CurrentPlayerShip.GetComponent<HealthScript>();
            if (healthScript != null)
            {
                healthScript.CurrentHealth = 0;
            }
            Destroy(CurrentPlayerShip.gameObject);
        }
    }
}

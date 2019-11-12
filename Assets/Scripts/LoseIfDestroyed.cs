using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseIfDestroyed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        var healthScript = gameObject.GetComponent<HealthScript>();
        if (healthScript != null)
        {
            if (healthScript.CurrentHealth == 0)
            {
                SceneManager.LoadScene("Lose");
            }
        }
    }
}

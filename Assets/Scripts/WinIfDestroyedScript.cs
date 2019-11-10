﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class WinIfDestroyedScript : MonoBehaviour
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

    private void OnDestroy()
    {
        if (CurrentPlayerShip != null)
        {
            SceneManager.LoadScene("Win");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinIfDestroyedScript : MonoBehaviour
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
        SceneManager.LoadScene("Win");
        WinAfterTime(1);
    }

    IEnumerator WinAfterTime(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("Win");
    }
}

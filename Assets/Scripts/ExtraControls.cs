using UnityEngine;
using System.Collections;

public class ExtraControls : MonoBehaviour
{
    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Menu) || Input.GetKeyDown(KeyCode.M))
        {
            GoMenu();
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            RetryLevel();
        }

    }

    public void GoMenu()
    {
        Destroy(GameObject.FindWithTag("Soundtrack"));
        Destroy(GameObject.FindWithTag("ZoomManager"));
        Application.LoadLevel("Menu");
    }

    public void RetryLevel()
    {
        PlayerPrefs.SetInt("DistanceZ", GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().DistanceZ);        
        Application.LoadLevel(Application.loadedLevelName);
    }
}

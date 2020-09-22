using UnityEngine;
using System.Collections;

public class FinishLevel01 : MonoBehaviour {
    
    public string ProximoLevel;
    bool FOV;
    int i = 60;

    void OnTriggerEnter(Collider info)
    {
        if (info.tag == "Player")
        {
            FOV = true;   
            if (GameObject.FindWithTag("Timer").GetComponent<Timer>().timer < PlayerPrefs.GetFloat(Application.loadedLevelName) || PlayerPrefs.GetFloat(Application.loadedLevelName) < 1)
            {
                PlayerPrefs.SetFloat(Application.loadedLevelName, GameObject.FindWithTag("Timer").GetComponent<Timer>().timer);
            }
            GameObject.FindWithTag("Respawn").GetComponent<RespawnFall>().Mortal = false;
        }
    }

    void Update()
    {
        if (FOV == true)
        {            
            i += 2;
            GameObject.FindWithTag("MainCamera").GetComponent<Camera>().fieldOfView = i;
            GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().DistanceZ++;
            if (i >= 179)
            {
                Application.LoadLevel(ProximoLevel);
                Destroy(GameObject.FindWithTag("Soundtrack"));
                Destroy(GameObject.FindWithTag("ZoomManager"));
            }
        
        }
    }
}

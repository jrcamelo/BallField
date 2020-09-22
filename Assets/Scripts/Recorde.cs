using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Recorde : MonoBehaviour {

    public GameObject RecordeTexto;

    // Use this for initialization
    void Start ()
    {


        float timer = PlayerPrefs.GetFloat(Application.loadedLevelName);        
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        
        GetComponent<Text>().text = niceTime;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

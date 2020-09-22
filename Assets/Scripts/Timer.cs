using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

    public GameObject timerObject;
    private UnityEngine.UI.Text compText;
    public float timer;

    // Use this for initialization
	void Start () {
        compText = timerObject.GetComponent<Text>();	
	}
	
	// Update is called once per frame
	void LateUpdate () {

        timer += Time.deltaTime;

        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        compText.text = niceTime;        
	}
}

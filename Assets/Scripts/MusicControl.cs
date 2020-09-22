using UnityEngine;
using System.Collections;

public class MusicControl : MonoBehaviour {

    public float Volume = 0.5f;
    public GameObject Soundtrack;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.PageUp) && Volume <= 1)
        {
            Volume += 0.01f;
        }

        if (Input.GetKey(KeyCode.PageDown) && Volume >= 0)
        {
            Volume -= 0.01f;
        }

        Soundtrack.GetComponent<AudioSource>().volume = Volume;
	}
}

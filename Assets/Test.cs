using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

    public static float Time;
    
	// Update is called once per frame

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

}

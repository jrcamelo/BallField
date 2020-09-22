using UnityEngine;
using System.Collections;

public class SoundtrackSingleton : MonoBehaviour
{
    private static SoundtrackSingleton instance = null;
    public static SoundtrackSingleton Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}

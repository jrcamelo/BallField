using UnityEngine;
using System.Collections;

public class CameraSingleton : MonoBehaviour
{
    private static CameraSingleton instance = null;
    public static CameraSingleton Instance
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

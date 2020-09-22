using UnityEngine;
using System.Collections;

public class RespawnFall : MonoBehaviour
{
    public string Level;
    public int MaxFallDistance;
    public GameObject BallPlayer;
    public GameObject RespawnPoint;
    public bool Reset;
    public bool Mortal;

    void Update()
    {
        if (BallPlayer.transform.position.y <= MaxFallDistance && Mortal == true)
        {
            Reload();
        }
    }

    void OnTriggerEnter(Collider info)
    {
        if (info.tag == BallPlayer.tag)
        {
            Reload();
        }
    }

    public void Reload()
    {
        PlayerPrefs.SetInt("DistanceZ", GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().DistanceZ);

        if (Reset == true)
        {
            Application.LoadLevel(Level);
        }
        else
        {
            BallPlayer.GetComponent<Transform>().localPosition = RespawnPoint.GetComponent<Transform>().localPosition;
        }
    }
}



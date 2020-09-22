using UnityEngine;
using System.Collections;

public class StartLevel : MonoBehaviour {

    public string Level;
    	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void Run()
    {
        if (Level == "Exit")
        {
            Exit();
        }
        Destroy(GameObject.FindWithTag("MainCamera"));
        Destroy(GameObject.FindWithTag("Soundtrack"));
        Application.LoadLevel(Level);
    }

    public void Exit()
    {
        Application.Quit();
    }
}

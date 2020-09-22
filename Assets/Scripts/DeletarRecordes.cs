using UnityEngine;
using System.Collections;

public class DeletarRecordes : MonoBehaviour {

	public void Deletar()
    {
            PlayerPrefs.DeleteAll();       
    }
}

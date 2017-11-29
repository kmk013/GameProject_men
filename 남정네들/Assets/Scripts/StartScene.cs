using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour {

    private void Start()
    {
        Screen.SetResolution(1024, 768, false);
    }

    void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(1);
        }
	}
}

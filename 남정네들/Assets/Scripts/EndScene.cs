using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour {
    
    public void restartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void exitButton()
    {
        Application.Quit();
    }
}

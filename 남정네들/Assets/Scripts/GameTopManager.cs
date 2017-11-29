using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTopManager : MonoBehaviour {

    public static GameTopManager instance;
	
    void Awake()
    {
        GameTopManager.instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}

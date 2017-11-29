using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dongyeon : Enemy {

	void Start () {
        id = 0;
        answerId = 1;

        Init();
    }
	
	void Update () {
		if(!isAngry)
            GetInput();
        else if(isAngry)
            Angry();
	}

    public override void Angry()
    {
        base.Angry();
        enemyTransparency();
    }

    void enemyTransparency()
    {
        Color color = new Color(GetComponent<Renderer>().material.color.r,
            GetComponent<Renderer>().material.color.g,
            GetComponent<Renderer>().material.color.b,
            0.0f);
        GetComponent<Renderer>().material.color = color;
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jamin : Enemy {

    void Start () {
        id = 1;
        answerId = Random.Range(0, 3);

        Init();
    }
	
	void Update () {
        if (!isAngry)
            GetInput();
        else if (isAngry)
            Angry();
    }
}

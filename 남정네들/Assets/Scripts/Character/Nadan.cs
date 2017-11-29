﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nadan : Enemy
{
    void Start()
    {
        id = 19;
        answerId = Random.Range(0, 3);

        Init();
    }

    void Update()
    {
        if (!isAngry)
            GetInput();
        else if (isAngry)
            Angry();
    }
}

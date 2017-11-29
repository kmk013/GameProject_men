using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juho : Enemy
{
    void Start()
    {
        id = 15;
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

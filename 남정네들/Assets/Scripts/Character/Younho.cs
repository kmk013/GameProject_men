using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Younho : Enemy
{
    void Start()
    {
        id = 8;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jihwan : Enemy
{
    void Start()
    {
        id = 17;
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

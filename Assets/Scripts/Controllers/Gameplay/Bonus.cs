using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public int points;
    public bool toSpin;
    public float spinRateDegrees;


    void Update()
    {
        if (!toSpin) return;
        transform.Rotate(0, spinRateDegrees * Time.deltaTime, 0);
    }
}
